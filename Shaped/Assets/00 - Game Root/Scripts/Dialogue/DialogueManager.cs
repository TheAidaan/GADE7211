using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    const float PLAYER_TEXT_DELAY = 0.04f;

    public static DialogueManager instance; //single...

    Graph _dialogueGraph = new Graph();
    Vertex _currentDialogueVertex;
   
    DoublyLinkedList _dialogueList = new DoublyLinkedList();
    ListDialogueNode _currentDialogueNode;


    RectTransform _npcArea, _playerArea;
    TextMeshProUGUI _npcNameTxt, _DialogueTxt,_playerTxt;
    Image _npcIcon;

    DialogueChoiceManager _choices;


    DialogueBox _dialogueBox;

    Character _currentNPC;

    bool _typing, _stoptyping,_branchedNarrative, _npcSpeaking, _onlyOneChoice, _endDialogue;
    static bool _activeDialogue;
    public static bool activeDialogue { get { return _activeDialogue; } }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
       //GameObject dialogueBox = GetComponentInChildren<Image>().gameObject;

        _dialogueBox = GetComponentInChildren<DialogueBox>();

        _npcArea = (RectTransform)_dialogueBox.transform.GetChild(0);
        _npcNameTxt = _npcArea.GetComponent<TextMeshProUGUI>();
        _npcIcon = _npcNameTxt.GetComponentInChildren<Image>();

        _playerArea = (RectTransform)_dialogueBox.transform.GetChild(1);
        _playerTxt = _playerArea.GetComponent<TextMeshProUGUI>();

        _DialogueTxt = _dialogueBox.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        _choices = GetComponentInChildren<DialogueChoiceManager>();

        _activeDialogue = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (_activeDialogue)
        {

            AlertBox.Static_Hide();//player should see that they are able to choose to talk to the npc they are currently talking to

            if (Input.GetKeyDown(KeyCode.E)) // move the conversation forward
                if (!_branchedNarrative || _onlyOneChoice) // if there are no dialogue choices at all, the player must maually move the conversation forward
                    if (_typing) // next frame will be the full text or the next exchange
                        _stoptyping = true;
                    else
                        NextExchange();

                    
        }
    }

    void NextExchange()           //List
    {
        if (!_branchedNarrative)
        {
            if (_npcSpeaking)
            {
                List_PlayerResponse(); // every npc response has a player response 
            }
            else
            {
                _currentDialogueNode = _dialogueList.Next(); //npc response is always first 
                if (_currentDialogueNode != null)
                    List_NPCResponse();
                else
                    EndDialogue();
            }
        }
        else
        {
            if (_endDialogue)
                EndDialogue();
            else
                Graph_PlayerResponse();
        }
        
    }


    IEnumerator RunDialogue(string text, float delay)             //ALL        
    {
        _typing = true; // lets everybody know its typing

        for (int i = 0;i < text.Length + 1; i++)
        {
            _DialogueTxt.text = text.Substring(0,i); //add a character to the end of the text
            yield return new WaitForSeconds(delay); // waits a while

            if (_stoptyping)
            {
                _stoptyping = false; // stopped typing
                _typing = false; // stopped typing
                _DialogueTxt.text = text; // show the full text that was stopped

                break;
            }
        }

        
       yield return new WaitForSeconds(delay); // waits a while
        _typing = false;

        if (_branchedNarrative)
        {
            if (_currentDialogueVertex.Data.Responses.Count != 1) // if there are more than one choices 
                _choices.ActivateButtons(_currentDialogueVertex.Data.Responses);

            else if (_onlyOneChoice) // should only get here if player has used the only "choice"
                _endDialogue = true;//the only time where there should be one reponse should be at the end of the conversation
            else
            _onlyOneChoice = true;
            
        }
        else if (_currentDialogueNode != null)
            if (_currentDialogueNode.Interupt && !_npcSpeaking)
                NextExchange();
    }

    void Graph_PlayerResponse()
    {
        _npcArea.gameObject.SetActive(false);
        _playerArea.gameObject.SetActive(true);

        _DialogueTxt.alignment = TextAlignmentOptions.TopRight;

        StartCoroutine(RunDialogue(_currentDialogueVertex.Data.Responses.ElementAt(0).Text, PLAYER_TEXT_DELAY));       ///List

        if (_currentDialogueVertex.Data.Responses.ElementAt(0).Effect != 0)
            PlayerStats.Static_ObjectiveCompleter(_currentDialogueVertex.Data.Responses.ElementAt(0).Effect);
    }

    void List_PlayerResponse()
    {
        _npcSpeaking = false;

        _npcArea.gameObject.SetActive(false);
        _playerArea.gameObject.SetActive(true);
        _DialogueTxt.alignment = TextAlignmentOptions.TopRight;

        StartCoroutine(RunDialogue(_currentDialogueNode.Response, PLAYER_TEXT_DELAY));       ///List
    }

    void List_NPCResponse()
    {
        _npcSpeaking = true;

        _playerArea.gameObject.SetActive(false);
        _npcArea.gameObject.SetActive(true);
        _DialogueTxt.alignment = TextAlignmentOptions.TopLeft;

        StartCoroutine(RunDialogue(_currentDialogueNode.NPCText, _currentNPC.TextDelay));       ///List
    }
    void EndDialogue()          //All       
    {
        _currentNPC.IsTalking = false;

        _dialogueGraph.Clear();
        _dialogueList.Clear();

        _currentDialogueVertex = null;
        _activeDialogue = false;

        _currentDialogueNode = null;

        _playerArea.gameObject.SetActive(false);  //preparing fot the next NPC text
        _npcArea.gameObject.SetActive(true);
        _DialogueTxt.alignment = TextAlignmentOptions.TopLeft;

        _dialogueBox.HideDialogueBox();

        _onlyOneChoice=false;
        _endDialogue = false;

        PlayerInventory.Static_DisplayItems();
    }

    /*              PUBLIC STATICS RECEIVERS             */                                                 /*              PUBLIC STATICS RECEIVERS             */                                             /*              PUBLIC STATICS RECEIVERS             */

    
    void LoadGraph(TextAsset asset)     //graph
    {
        GraphDialogue JsonNodes = new GraphDialogue();

        JsonNodes = JsonUtility.FromJson<GraphDialogue>(asset.text); // put it into a generic list

        foreach (GraphDialogueNode node in JsonNodes.Dialogue)
        {
            instance.AddToGraph(node);
        }
        instance.ActivateDialogue(); // send the NPC name 
    }

    void AddToGraph(GraphDialogueNode node)     //graph
    {
        _dialogueGraph.AddNode(node);
    }

    void Response(int responseID)       //graph
    {
        if (!_dialogueGraph.Empty)
            if (!_currentDialogueVertex.Edges.Any())
                EndDialogue();
            else
            {
                if (_currentDialogueVertex.Edges.Count() <= responseID)
                    EndDialogue();
                else
                {
                    _currentDialogueVertex = _currentDialogueVertex.Edges.ElementAt(responseID);
                    StartCoroutine(RunDialogue(_currentDialogueVertex.Data.NPCText, _currentNPC.TextDelay));
                }
            }
    }

    public void ChangeDialogueOptionText(string message)            //All
    {
        if (message == string.Empty)
        {
            AlertBox.Static_Hide(); // Hide the alert
        }
        else // activate the text and display the message
        {
            AlertBox.Static_DialogueAlert(message);
        }
    }
    void SetNPC(Character NPC)       //All
    {
        _currentNPC = NPC;
        _currentNPC.IsTalking = true;

        _npcNameTxt.text = _currentNPC.Name;

        Sprite npcIcon = GameManager.GameIcons[NPC.IconID];

        if (npcIcon != null) // is there even an asset
        {
            _npcIcon.sprite = npcIcon; // if yes the show it
        }
        else
        {
            Debug.Log("No NPC icon"); // this is why it's not working
        }
    }
    void ActivateDialogue()         //All                                
    {
        _playerArea.gameObject.SetActive(false);
        _npcArea.gameObject.SetActive(true);
        _DialogueTxt.alignment = TextAlignmentOptions.TopLeft;

        _activeDialogue = true;
        _dialogueBox.ShowDialogueBox();

        if (_branchedNarrative)
        {
            _currentDialogueVertex = _dialogueGraph.Start();
            StartCoroutine(RunDialogue(_currentDialogueVertex.Data.NPCText, _currentNPC.TextDelay));
        }
        else
        {
            _currentDialogueNode = _dialogueList.Start();
            List_NPCResponse();
        }

        _npcSpeaking = true;
        PlayerInventory.Static_HideAllSlots();

    }
    void LoadList(TextAsset asset)      //list
    {
        ListDialogueNodes JsonNodes = new ListDialogueNodes();

        JsonNodes = JsonUtility.FromJson<ListDialogueNodes>(asset.text); // put it into a generic list


        foreach (ListDialogueNode node in JsonNodes.Dialogue)
            instance.AddToList(node); // puts it into linked list

        instance.ActivateDialogue(); // send the NPC name 
    }
    void AddToList(ListDialogueNode node)       //list
    {
        _dialogueList.AddNode(node);
    }

    
    /*              PUBLIC STATICS             */                                                 /*              PUBLIC STATICS             */                                             /*              PUBLIC STATICS             */


    public static void LoadFile(Character NPC) //anyone can call this = anyone can speak
    {
        TextAsset asset = Resources.Load<TextAsset>("DialogueFiles/" + NPC.File); // get the text asset with the NPC file name 
        if (asset != null) //was there a text asset?
        {
            InitalChecks check = JsonUtility.FromJson<InitalChecks>(asset.text); // checking if the file should be loaded into a graph or a linked list

            instance.SetNPC(NPC);
            instance._branchedNarrative = check.BranchedNarrative;

            if (check.BranchedNarrative)
                instance.LoadGraph(asset);
            else
                instance.LoadList(asset);

            if (check.Rude)
                PlayerStats.Static_TakeDamage();
        }
        else
        {
            Debug.Log("No json file for " + NPC.Name + " file name" + NPC.File);
        }
            
        
    }
    public static void Static_Response(int responseID)          //Graph
    {
        instance.Response(responseID);
    }

    public static void GiveDialogueOption(string name) // get the NPC name that the player might talk to 
    {
        if (name != string.Empty)
        {
            instance.ChangeDialogueOptionText("Press [SPACE] to talk to " + name); // format the message if the string has a name
        }
        else
        {
            instance.ChangeDialogueOptionText(string.Empty); // dont format the name and send an empty string if there's no npc name given
        }
    }
}

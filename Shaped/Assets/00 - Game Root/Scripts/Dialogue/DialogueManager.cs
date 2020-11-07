using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    Character Test = new Character("Trapezium", 2, 0.05f, 1);

    public static DialogueManager instance; //single...

    Graph _dialogueGraph = new Graph();
    Vertex _currentDialogueVertex;
   
    DoublyLinkedList _dialogueList = new DoublyLinkedList();
    ListDialogueNode _currentDialogueNode;

    TextMeshProUGUI _npcNametxt, _npcDialoguetxt;
    Image _npcIcon;

    ResponseManager _responseManager;

    TextMeshProUGUI _dialogueOptiontxt;
    DialogueBox _dialogueBox;

    Character _currentNPC;

    bool _typing, _stoptyping,_branchedNarrative;
    static bool _activeDialogue;
    public static bool activeDialogue { get { return _activeDialogue; } }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GameObject dialogueBox = GetComponentInChildren<Image>().gameObject; 

        _npcNametxt = dialogueBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _npcIcon = _npcNametxt.GetComponentInChildren<Image>();
        _npcDialoguetxt = dialogueBox.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        _responseManager = GetComponentInChildren<ResponseManager>();

        _dialogueOptiontxt = GetComponentInChildren<TextMeshProUGUI>();
        _dialogueBox = GetComponentInChildren<DialogueBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_activeDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Q))    // player can't move player character anymore so A only moves the dialogue backwards
                if (_typing)
                    _stoptyping = true;

            _dialogueOptiontxt.gameObject.SetActive(false); //player should see that they are able to choose to talk to the npc they are currently talking to

            if (Input.GetKeyDown(KeyCode.E) && !_branchedNarrative) // move the conversation forward
                    NextExchange(); 
        }
    }

    void NextExchange()           //List
    {
        _currentDialogueNode = _dialogueList.Next();
        if (_currentDialogueNode != null)
        {
            StartCoroutine(RunDialogue(_currentDialogueNode.NPCText));
            return;
        }

        EndDialogue();
    }


    IEnumerator RunDialogue(string NPCText)             //ALL        
    {
        _typing = true; // lets everybody know its typing

        for (int i = 0;i < NPCText.Length + 1; i++)
        {
            _npcDialoguetxt.text = NPCText.Substring(0,i); //add a character to the end of the text
            yield return new WaitForSeconds(_currentNPC.textDelay); // waits a while

            if (_stoptyping)
            {
                _stoptyping = false; // stopped typing
                _typing = false; // stopped typing
                _npcDialoguetxt.text = NPCText; // show the full text that was stopped

                break;
            }
        }
        yield return new WaitForSeconds(_currentNPC.textDelay); // waits a while

        if (_branchedNarrative)
        {
            _dialogueBox.ShowDialogueBox(_currentDialogueVertex.Data.Responses.Count());
            _responseManager.ActivateButtons(_currentDialogueVertex.Data.Responses);
        }
        else
        {

        }
       
    }
    void EndDialogue()          //All
    {
        _dialogueGraph.Clear();
        _dialogueList.Clear();

        _currentDialogueVertex = null;
        _activeDialogue = false;

        _dialogueBox.HideDialogueBox();
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
        if (!_currentDialogueVertex.Edges.Any())
            EndDialogue();
        else
        {
            if (_currentDialogueVertex.Edges.Count() <= responseID)
                EndDialogue();
            else
            {
                _currentDialogueVertex = _currentDialogueVertex.Edges.ElementAt(responseID);
                StartCoroutine(RunDialogue(_currentDialogueVertex.Data.NPCText));
            }
        }
    }

    public void ChangeDialogueOptionText(string message)            //All
    {
        if (message == string.Empty)
        {
            _dialogueOptiontxt.gameObject.SetActive(false); // turn off the text if the string is empty 
        }
        else // activate the text and display the message
        {
            _dialogueOptiontxt.gameObject.SetActive(true);
            _dialogueOptiontxt.text = message;

        }
    }
    void SetNPC(Character NPC)       //All
    {
        _currentNPC = NPC;

        _npcNametxt.text = _currentNPC.name;

        Sprite npcIcon = GameManager.sprites[NPC.iconID];

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
        _activeDialogue = true;
        _dialogueBox.ShowDialogueBox(0);

        if (_branchedNarrative)
        {
            _currentDialogueVertex = _dialogueGraph.Start();
            StartCoroutine(RunDialogue(_currentDialogueVertex.Data.NPCText));
        }
        else
        {
            _currentDialogueNode = _dialogueList.Start();
            StartCoroutine(RunDialogue(_currentDialogueNode.NPCText));
        }


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
        TextAsset asset = Resources.Load<TextAsset>("DialogueFiles/" + NPC.file); // get the text asset with the NPC file name 
        if (asset != null) //was there a text asset?
        {
            NarrativeTypeCheck  check = JsonUtility.FromJson<NarrativeTypeCheck>(asset.text); // checking if the file should be loaded into a graph or a linked list

            instance.SetNPC(NPC);
            instance._branchedNarrative = check.BranchedNarrative;

            if (check.BranchedNarrative)
                instance.LoadGraph(asset);
            else
                instance.LoadList(asset);

            
            
        }else
        {
            Debug.Log("No json file");
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

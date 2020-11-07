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
        _activeDialogue = false;
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

            //if (Input.GetKeyDown(KeyCode.E)) // move the conversation forward
            //{
            //    if (!_typing)
            //    {
            //        NextExchange();
            //    }
            //}
        }

        if (Input.GetKeyDown(KeyCode.Space))
            LoadFile(Test);

        if (Input.GetKeyDown(KeyCode.A)) { }
        //LoadFile("Test 1");
    }


    IEnumerator RunDialogue()
    {
        _typing = true; // lets everybody know its typing

        for (int i = 0;i < _currentDialogueVertex.Data.NPCText.Length + 1; i++)
        {
            _npcDialoguetxt.text = _currentDialogueVertex.Data.NPCText.Substring(0,i); //add a character to the end of the text
            yield return new WaitForSeconds(_currentNPC.textDelay); // waits a while

            if (_stoptyping)
            {
                _stoptyping = false; // stopped typing
                _typing = false; // stopped typing
                _npcDialoguetxt.text = _currentDialogueVertex.Data.NPCText; // show the full text that was stopped

                break;
            }
        }
        yield return new WaitForSeconds(_currentNPC.textDelay); // waits a while

        _dialogueBox.ShowDialogueBox(_currentDialogueVertex.Edges.Count());
        _responseManager.ActivateButtons(_currentDialogueVertex.Data.Responses);
    }
    void EndDialogue()
    {
        _dialogueGraph.Clear();
        _currentDialogueVertex = null;

        _dialogueBox.HideDialogueBox();
    }

    /*              PUBLIC STATICS RECEIVERS             */

    void AddToGraph(GraphDialogueNode node)
    {
        _dialogueGraph.AddNode(node);
    }

    void AddToList(ListDialogueNode node)
    {
        _dialogueList.AddNode(node);
    }


    void SetNPC(Character NPC)
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
    void ActivateDialogue()
    {
        _currentDialogueVertex = _dialogueGraph.Start();
        _dialogueBox.ShowDialogueBox(0);

        StartCoroutine(RunDialogue());

    }

    void Response(int responseID)
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
                StartCoroutine(RunDialogue());
            }
        }
    }

    public void ChangeDialogueOptionText(string message)
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
    void LoadList(TextAsset asset)
    {
        ListDialogueNodes JsonNodes = new ListDialogueNodes();

        JsonNodes = JsonUtility.FromJson<ListDialogueNodes>(asset.text); // put it into a generic list


        foreach (ListDialogueNode node in JsonNodes.Dialogue)
        {
            instance.AddToList(node); // puts it into linked list
        }

        instance.ActivateDialogue(); // send the NPC name 
    }

    void LoadGraph(TextAsset asset)
    {
        GraphDialogue JsonNodes = new GraphDialogue();

        JsonNodes = JsonUtility.FromJson<GraphDialogue>(asset.text); // put it into a generic list

        foreach (GraphDialogueNode node in JsonNodes.Dialogue)
        {
            instance.AddToGraph(node);
        }
        instance.ActivateDialogue(); // send the NPC name 
    }

    /*              PUBLIC STATICS              */

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
    public static void Static_Response(int responseID)
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

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
    Vertex _currentDialogue;
    //DoublyLinkedList _dialogueList = new DoublyLinkedList();

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

        for (int i = 0;i < _currentDialogue.Data.NPCText.Length + 1; i++)
        {
            _npcDialoguetxt.text = _currentDialogue.Data.NPCText.Substring(0,i); //add a character to the end of the text
            yield return new WaitForSeconds(_currentNPC.textDelay); // waits a while

            if (_stoptyping)
            {
                _stoptyping = false; // stopped typing
                _typing = false; // stopped typing
                _npcDialoguetxt.text = _currentDialogue.Data.NPCText; // show the full text that was stopped

                break;
            }
        }
        yield return new WaitForSeconds(_currentNPC.textDelay); // waits a while

        _dialogueBox.ShowDialogueBox(_currentDialogue.Edges.Count());
        _responseManager.ActivateButtons(_currentDialogue.Data.Responses);
    }
    void EndDialogue()
    {
        _dialogueGraph.Clear();
        _currentDialogue = null;

        _dialogueBox.HideDialogueBox();
    }

    /*              PUBLIC STATICS RECEIVERS             */

    void AddToCurrentDialogue(GraphDialogueNode node)
    {
        _dialogueGraph.AddNode(node);
    }

    void ActivateDialogue(Character NPC)
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

        _currentDialogue = _dialogueGraph.Start();
        _dialogueBox.ShowDialogueBox(0);

        StartCoroutine(RunDialogue());

    }

    void Response(int responseID)
    {
        if (!_currentDialogue.Edges.Any())
            EndDialogue();
        else
        {
            if (_currentDialogue.Edges.Count() <= responseID)
                EndDialogue();
            else
            {
                _currentDialogue = _currentDialogue.Edges.ElementAt(responseID);
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
    void LoadList(Character NPC)
    {
        _branchedNarrative = false;
    }
    void LoadGraph(Character NPC)
    {
        GraphDialogue JsonNodes = new GraphDialogue();
        Debug.Log(NPC.file);
        TextAsset asset = Resources.Load<TextAsset>("DialogueFiles/" + NPC.file); // get the text asset with the NPC file name 
        if (asset != null) //was there a text asset?
        {
            JsonNodes = JsonUtility.FromJson<GraphDialogue>(asset.text); // put it into a generic list

            foreach (GraphDialogueNode node in JsonNodes.Dialogue)
            {
                instance.AddToCurrentDialogue(node);
            }
            instance.ActivateDialogue(NPC); // send the NPC name 
        }
        else
        {
            Debug.Log("No json file.");
        }

        _branchedNarrative = true;
    }

    /*              PUBLIC STATICS              */

    public static void LoadFile(Character NPC) //anyone can call this = anyone can speak
    {
        instance.LoadGraph(NPC);
        
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

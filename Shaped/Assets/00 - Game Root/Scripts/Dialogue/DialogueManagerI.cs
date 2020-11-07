using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


[Serializable]
public class Response //json 
{
    public string Text;
}

[Serializable]
public class GraphDialogueNode //json 
{
    public string ID;
    public string Connections;
    public string NPCText;
    public List<Response> Responses = new List<Response>();
}

[Serializable]
public class GraphDialogue//json
{
    public List<GraphDialogueNode> Dialogue = new List<GraphDialogueNode>();
}


/*-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-*/


public class DialogueManagerI : MonoBehaviour
{
    public static DialogueManagerI instance; //single...

    Graph _dialogueGraph = new Graph();
    Vertex _currentDialogue;

    TextMeshProUGUI _npcNametxt, _npcDialoguetxt;
    Image _npcIcon;

    ResponseManager _responseManager;

    TextMeshProUGUI _dialogueOptiontxt;
    DialogueBox _dialogueBox;
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
        if (Input.GetKeyDown(KeyCode.Space))
            LoadFile("Test");

        if (Input.GetKeyDown(KeyCode.A))
            LoadFile("Test 1");
    }

    void AddToCurrentDialogue(GraphDialogueNode node)
    {
        _dialogueGraph.AddNode(node);
    }
    void ActivateDialogue()
    {
        _currentDialogue = _dialogueGraph.Start();
        RunDialogue();
        
    }
    void RunDialogue()
    {
        _npcDialoguetxt.text = _currentDialogue.Data.NPCText;
        _responseManager.ActivateButtons(_currentDialogue.Data.Responses);
    }
    void EndDialogue()
    {
        _dialogueGraph.Clear();
        _currentDialogue = null;
    }

    public void LoadFile(string file) //anyone can call this = anyone can speak
    {
        GraphDialogue JsonNodes = new GraphDialogue();

        TextAsset asset = Resources.Load<TextAsset>("DialogueFiles/" + file); // get the text asset with the NPC file name 
        if (asset != null) //was there a text asset?
        {
            JsonNodes = JsonUtility.FromJson<GraphDialogue>(asset.text); // put it into a generic list

            foreach (GraphDialogueNode node in JsonNodes.Dialogue)
            {
                AddToCurrentDialogue(node);
            }
            ActivateDialogue(); // send the NPC name 
        }
        else
        {
            Debug.Log("No json file.");
        }
    }
    public static void Static_Response(int responseID)
    {
        instance.Response(responseID);
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
                RunDialogue();
            }

        }
    }

    
}

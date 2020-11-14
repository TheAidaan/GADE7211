using System;
using System.Collections.Generic;

[Serializable]
public class InitalChecks //json 
{
    public bool BranchedNarrative;
    public bool Rude;
}


/*              FOR THE GRAPH            */

[Serializable]
public class Response //json 
{
    public string Text;
    public int ItemRequired;
    public int ObjectiveRequired;
    public int Effect;

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

/*              FOR THE LIST            */

[Serializable]
public class ListDialogueNode //json 
{
    public string NPCText;
    public string Response;
    public int Effect;
    public bool Interupt;
}
[Serializable]
public class ListDialogueNodes//json
{
    public int ExternalItemRequired;
    public int InternalItemRequired;
    public List<ListDialogueNode> Dialogue = new List<ListDialogueNode>();
    public int missionID;
}
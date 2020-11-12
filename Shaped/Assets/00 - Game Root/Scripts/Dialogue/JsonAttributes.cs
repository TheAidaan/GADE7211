using System;
using System.Collections.Generic;

[Serializable]
public class NarrativeTypeCheck //json 
{
    public bool BranchedNarrative;
}


/*              FOR THE GRAPH            */

[Serializable]
public class Response //json 
{
    public string Text;
    public int ItemRequired;
}

[Serializable]
public class GraphDialogueNode //json 
{   public string ID;
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
    public bool Interupt;
}
[Serializable]
public class ListDialogueNodes//json
{
    public int itemKeyRequired;
    public List<ListDialogueNode> Dialogue = new List<ListDialogueNode>();
    public int missionID;
}
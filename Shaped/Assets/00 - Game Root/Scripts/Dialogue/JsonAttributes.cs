using System;
using System.Collections.Generic;

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

[Serializable]
public class ListDialogue //json 
{
    public string NPCText;
    public string Response;
    public bool Interupt;
}
[Serializable]
public class ListDialogueNodes//json
{
    public int itemKeyRequired;
    public List<ListDialogue> dialogue = new List<ListDialogue>();
    public int missionID;
}
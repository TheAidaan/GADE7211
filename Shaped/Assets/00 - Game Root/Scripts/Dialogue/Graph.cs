using System.Collections.Generic;
using System.Linq;

class Vertex
{
    public char ID;

    public GraphDialogueNode Data;
    public List<Vertex> Edges = new List<Vertex>();

    public Vertex(GraphDialogueNode data)
    {
        this.Data = data;
        this.ID = data.ID[0];
    }
}

class Graph
{
    List<Vertex> _vertices = new List<Vertex>();
   
    public void AddNode(GraphDialogueNode Data)
    {
        Vertex node = new Vertex(Data);
        _vertices.Add(node);
    }

    void Sort(Vertex node)
    {
        char[] connections = node.Data.Connections.ToCharArray();
        char current = connections[0];

        if (!current.Equals('Z')) // if there are no connections the first entry will be Z, and there would be no point in going to add eddges
            for (int i = 0; i < connections.Length; i++)
                foreach (Vertex vertex in _vertices)
                {
                    current = connections[i];

                    if (vertex.ID.Equals(current)) //if found the necess
                        node.Edges.Add(vertex);
                }                 
    }

    public void Clear()
    {
        _vertices.Clear();
    }

    public Vertex Start()
    {
        foreach(Vertex node in _vertices)
        {
            Sort(node);
        }

        return _vertices.First();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

class Node //for doubly
{
    public ListDialogue Data; // found in DialogueManager.cs
    public Node Next;
    public Node(ListDialogue data)
    {
        this.Data = data;
    }
}
public class LinkedList  // can add, clear, return Data both ways
{
    Node _head; // the start of the list

    Node _temp; // random point

    Node _pointer; // the working point 


    public void AddNode(ListDialogue Data)//adds to the end
    {
        Node Node = new Node(Data);

        if (_head == null) //is there a list
        {
            _head = Node; //make a list that starts with _head
            _head.Next = null;
        }
        else
        {
            _pointer = _head; //currently working with _head

            while (_pointer.Next != null)
            {
                _pointer = _pointer.Next; //current is actually last
            }

            _pointer.Next = Node;// tell the last node whats Next
            Node.Next = null;//emphasize that the new Data is at the end

        }

        _pointer = _head; //point to _head when adding(for now(maybe))
    }
    public void Clear()//kills 'em all
    {
        _temp = _head;
        while (_temp != null)// cant clear whats already clear
        {
            _pointer = _temp.Next; // point to the Next node

            _temp.Data = null; //delete Data

            _temp = _pointer;
        }
        _head = null; // makes it offical 
        _pointer = null;

    }
    public ListDialogue Start() //the function that starts it all
    {
        return _head.Data;
    }

    public ListDialogue Next()//moves along
    {
        if (_pointer != null) // is there evens a list
        {
            if (_pointer.Next != null)  // if i have Data to send then there could be Data following this...
            {
                _pointer = _pointer.Next;  // ... so point to the Next node
            }
            else
            {
                return null; //if the pointer gave a null value then the list is done and the node sent was the last node in the value  
            }

            _temp = _pointer;
            return _temp.Data; //here's what you asked for           
        }
        else
        {
            return null;//it's pointing to the end or the list is clear
        }
    }
}

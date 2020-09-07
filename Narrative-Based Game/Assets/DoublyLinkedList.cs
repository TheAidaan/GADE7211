﻿class Node //for doubly
{
    public Dialogue data; // found in DialogueManager.cs
    public Node previous;
    public Node next;
    public Node(Dialogue data)
    {
        this.data = data;
    }
}
public class DoublyLinkedList  // can add, clear, return data both ways
{
    Node _head; // the start of the list

    Node _temp; //random point
    
    Node _pointer; // the working point 

    public void AddNode(Dialogue data)//adds to the end
    {
        Node Node = new Node(data);

        if (_head==null) //is there a list
        {
            _head = Node; //make a list that starts with _head
            _head.next = null;
            _head.previous = null;
        }else
        {
            _pointer = _head; //currently working with _head

            while(_pointer.next != null)
            {
                _pointer = _pointer.next; //current is actually last
            }

            _pointer.next = Node;// tell the last node whats next
            Node.previous = _pointer;// tell the new node what's behind
            Node.next = null;//emphasize that the new data is at the end
        }

        _pointer = _head; //point to _head when adding(for now(maybe))
    }
    public void Clear()
    {
        _temp = _head;
        while (_temp != null)// cant clear whats already clear
        {
            _pointer = _temp.next;

            _temp.previous = _temp.next = null;
            _temp.data = null;

            _temp = _pointer;
        }

        _pointer = null;

    } //kills them all
    public Dialogue Next()
    {
        if (_pointer != null) // is there evens a list
        {
            _temp = _pointer;
            if(_pointer.next != null) //if the list is not at the end
            {
                _pointer = _pointer.next;  // we're moving here
                
            }else
            {
                return null; // at the end 
            }
           
            return _temp.data; //here's what you asked for           
        }else
        {
            return null;//it's pointing to the end or the list is clear
        }   
    } //moves along
    public Dialogue Previous()
    {
        if (_pointer != null) // is there evens a llist
        {
            if (_pointer != _head) // if you're not pointing to the head
            {
                _temp = _pointer;
                
                if (_pointer.previous != null) // if you're not at the beginning..
                {
                    _pointer = _pointer.previous; //...move backwards
                }               

                return _temp.data; //here's what you asked for   
            }
            else
            {
                return _head.data; // if you're pointing to the end then send the head and don't do anything else
            }

        }
        else
        {
            return null;//the list is clear
        }
    }//comes back
}

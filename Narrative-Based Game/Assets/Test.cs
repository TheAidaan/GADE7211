using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{   
    int i=0;
    Text test;
    DoublyLinkedList list = new DoublyLinkedList();

    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<Text>();
       
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        list.AddNode(i);
    //        i++;
    //    }

    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        int data = list.Previous();

    //        if (data == -1)
    //        {
    //            test.text = "clear";
    //        }
    //        else
    //        {
    //            if (data == -2)
    //            {
    //                test.text = "beginning";
    //            }
    //            else
    //            {
    //                test.text = data.ToString();
    //            }
    //        }

    //    }

    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        list.Clear();
    //        i = 0;
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        int data = list.Next();

    //        if (data == -1)
    //        {
    //            test.text = "clear";
    //        }else
    //        {
    //            if (data == -2)
    //            {
    //                test.text = "end";
    //            }
    //            else
    //            {
    //                test.text = data.ToString();
    //            }
    //        }
            
    //    }
    //}
}

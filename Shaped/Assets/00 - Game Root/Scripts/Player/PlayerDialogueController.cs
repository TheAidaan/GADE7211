using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDialogueController : MonoBehaviour
{
    Character _npc; // the npc that the character is currently face. Player can choose whether or not to speak to them

    void Update()
    {
        if (FacingChattyNPC() && (!DialogueManager.activeDialogue))
        {
            DialogueManager.GiveDialogueOption(_npc.Name);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogueManager.LoadFile(_npc); // start the conversion by giving the NPC into to the dialogue manager
            }
        }
        else
        {
            DialogueManager.GiveDialogueOption(string.Empty); // if not infront of NPC or there is currently dialogue running, then send an empty string
        }

    }

    public bool FacingChattyNPC()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 15f, LayerMask.GetMask("Chatty")); // constantly ray cast for a NPC to talk to 

        if (hit)
        {
            _npc = hit.collider.gameObject.GetComponentInParent<NPC>().GetCharacterAttributes(); //take the specific NPC.cs from the raycast hit

            if (_npc.Name != null)//is there an NPC.cs attached?
            {
                return true;// offer the player a way the ability to talk to the NPC
            }
            else
            {
                Debug.Log("no NPC script attached to chatty NPC"); // this is why it's not working 
                return false;
            }
        }
        else 
        { 
            return false; 
        }// Do not offer the player a way the ability to talk to the NPC
        
    }
}

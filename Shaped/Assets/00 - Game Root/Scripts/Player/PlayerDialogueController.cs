using UnityEngine;
using System.Collections;


public class PlayerDialogueController : MonoBehaviour
{

    CharacterAnimator _anim; //used for the animator
    Character _lastNPC;
    Character _npc; // the npc that the character is currently facing. Player can choose whether or not to speak to them
    NPC _npcScript;

    bool _usingAlert = false;

    private void Start()
    {
        _anim = GetComponentInChildren<CharacterAnimator>();
    }
    void Update()
    {
        if (FacingChattyNPC() && !DialogueManager.activeDialogue)
        {
            if (!_usingAlert)
            {
                DialogueManager.GiveDialogueOption(_npc.Name);
                _usingAlert = true;
            }
          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _lastNPC = _npc;
                DialogueManager.LoadFile(_npc); // start the conversion by giving the NPC into to the dialogue manager
            }
        }
        else if (_usingAlert)
        {
            DialogueManager.GiveDialogueOption(string.Empty); // if not infront of NPC or there is currently dialogue running, then send an empty string
            _usingAlert = false;
        }
    }

    public bool FacingChattyNPC()
    {
        RaycastHit hit;

        Vector3 rayDirection;
        if (PlayerMovement.FacingLeft)
        {
            rayDirection = transform.right*-1;
        }
        else
        {
            rayDirection = transform.right;
        }

        if (Physics.Raycast(transform.position, rayDirection, out hit, 15f, LayerMask.GetMask("Chatty")))// constantly ray cast for a NPC to talk to 
        {
            _npcScript = hit.collider.gameObject.GetComponentInParent<NPC>();
            _npc = _npcScript.GetCharacterAttributes(); //take the specific NPC.cs from the raycast hit
            if (!_npc.Equals(_lastNPC))
            {
                if (_npc.Name != null)//is there an NPC.cs attached?
                {
                    return true;// offer the player a way the ability to talk to the NPC
                }
                else
                {
                    Debug.Log("no NPC script attached to chatty NPC"); // this is why it's not working 
                    return false;
                }
            }else
            { 
                return false;
            }
            
        }
        else 
        {
            _lastNPC = null;
            return false; 
        }// Do not offer the player a way the ability to talk to the NPC
        
    }
}

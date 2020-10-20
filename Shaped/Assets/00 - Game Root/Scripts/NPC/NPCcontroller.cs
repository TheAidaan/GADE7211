using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{   
    GameObject _target; // the current target for the navemesh to go to

    NavMeshAgent _agent; // the navmesh 
    Transform _sprite;// the 2D sprite

    NPC _npc; //used for the animator

    void Awake()
    {
        _sprite = GetComponentInChildren<Animator>().transform;//only the 2d sprite has an animator
        _npc = _sprite.GetComponent<NPC>();

        _agent = GetComponentInChildren<NavMeshAgent>();

        _target = GameObject.FindGameObjectWithTag("Target"); //REMOVE

        if (_target != null)
        {
            _agent.SetDestination(_target.transform.position);//REMOVE
        }
    }
    void FixedUpdate()
    {
        #region Setting the 3D mesh TARGET
        if (_target != null) //got anywhere to be?
        {
            _agent.SetDestination(_target.transform.position); //go!
        }

        #endregion

        #region Setting the 2D sprite DIRECTION
        if (_agent.velocity.x > 0) // if facing to the right
        {
            _sprite.localScale = new Vector3(-1, 1, 1); // face to the right
        }

        if (_agent.velocity.x < 0) // if facing to the left
        {
            _sprite.localScale = new Vector3(1, 1, 1); // face to the right
        }
        #endregion

        #region Setting the 2D sprite POSITION & ANIMATION
        Vector3 newPos = new Vector3(
            _agent.gameObject.transform.localPosition.x, 
            _sprite.localPosition.y, 
            _agent.gameObject.transform.localPosition.z); // set a new position for the 2D sprite to move to 

        if (newPos != _sprite.localPosition)
        {
            _sprite.localPosition = newPos;
            _npc.AnimateWalking(true); //walk
        }
        else
        {
            _npc.AnimateWalking(false); //idle
        }
        #endregion 
    }

    public void AssignSpeed(float speed)
    {
        _agent.speed = speed;
    }
}

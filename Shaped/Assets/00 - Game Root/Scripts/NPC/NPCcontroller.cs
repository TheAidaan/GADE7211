using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    readonly CharacterIdleState IdleState = new CharacterIdleState();
    readonly CharacterWalkingState WalkingState = new CharacterWalkingState();
    readonly CharacterTalkingState TalkingState = new CharacterTalkingState();

    public GameObject _target; // the current target for the navemesh to go to

    NavMeshAgent _agent; // the navmesh
    
    Transform _sprite;// the 2D sprit
    NPCAnimator _anim; //used for the animator

    bool goToTarget;

    Character _me;


    void Awake()
    {
        _sprite = GetComponentInChildren<Animator>().transform;
        _anim = _sprite.GetComponent<NPCAnimator>();

        _agent = GetComponentInChildren<NavMeshAgent>(); 
    }

    private void Start()
    {
        _anim.TransitionToState(IdleState);
    }

    void FixedUpdate()
    {
        #region Setting the 3D mesh TARGET

        if (_me.IsTalking) // am i talking?
        {
            _agent.isStopped = true;
            //_anim.TransitionToState(TalkingState); //Talking
        }
        else if (_target != null && goToTarget) //am i walking?
        {
            _anim.TransitionToState(WalkingState); //walk
            _agent.SetDestination(_target.transform.position); //go!

        }
        else // i should stay still
        {
            _anim.TransitionToState(IdleState); //idle
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
            
        }
        #endregion

    }

    private void Update()                       /////////////
    {
        if (Input.GetKeyDown(KeyCode.Z))
            goToTarget = true;
    }

    public void AssignSpeed(float speed)
    {
        _agent.speed = speed;
    }

    public void AssignSelf(Character me)
    {
        _me = me;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavAgentController : MonoBehaviour
{
    const float MOVE_SPEED = 12;

    readonly CharacterWalkingState WalkingState = new CharacterWalkingState();
    readonly CharacterIdleState IdleState = new CharacterIdleState();

    public Transform _target;
    NavMeshAgent _navAgent;

    Transform _sprite;// the 2D sprit

    CharacterAnimator _animator;
    static bool _navMeshActive;
    public static bool NavMeshActive { get { return _navMeshActive; } }
    // Start is called before the first frame update
    void Awake()
    {
        _sprite = GetComponentInChildren<Animator>().transform;
        _navAgent = GetComponentInChildren<NavMeshAgent>();
        _animator = GetComponentInChildren<CharacterAnimator>();
    }
    private void Start()
    {
        _navAgent.speed = MOVE_SPEED;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        #region Setting the nav mesh agents target
        if (_target != null /*&& goToTarget*/) //am i walking?
        {
            _navMeshActive = true;
            _animator.TransitionToState(WalkingState); //walk
            _navAgent.SetDestination(_target.transform.position); //go!
        }else
        {
            _navMeshActive = false;
            _animator.TransitionToState(IdleState); //walk
        }

        _navAgent.isStopped = !_navMeshActive;
        #endregion

        #region Setting the 2D sprite DIRECTION
        if (_navAgent.velocity.x > 0) // if facing to the right
        {
            _sprite.localScale = new Vector3(-1, 1, 1); // face to the right
        }

        if (_navAgent.velocity.x < 0) // if facing to the left
        {
            _sprite.localScale = new Vector3(1, 1, 1); // face to the right
        }
        #endregion

        #region Setting the 2D sprite POSITION & ANIMATION
        Vector3 newPos = new Vector3(
            _navAgent.gameObject.transform.localPosition.x,
            _sprite.localPosition.y,
            _navAgent.gameObject.transform.localPosition.z); // set a new position for the 2D sprite to move to 

        if (newPos != _sprite.localPosition)
        {
            _sprite.localPosition = newPos;

        }
        #endregion
    }
}

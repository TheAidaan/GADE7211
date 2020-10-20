using System.Collections;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    enum AnimationStates { idle, walking}
    AnimationStates currentState = AnimationStates.idle;
    Animator _anim;
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void ActivateWalkingAnimation(bool isWalking)
    {
        StartCoroutine(WalkingAnimation(isWalking));
    }
    IEnumerator WalkingAnimation(bool isWalking)
    {
        _anim.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            currentState = AnimationStates.walking;
        }else
        {
            currentState = AnimationStates.idle;
        }

        yield return null;
    }
}

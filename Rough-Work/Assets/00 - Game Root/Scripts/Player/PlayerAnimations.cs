using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator _anim;
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void WalkingAnimation(bool isWalking)
    {
        _anim.SetBool("isWalking", isWalking);
    }
}

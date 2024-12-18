using System;
using UnityEngine;

public class BossAnimationPlay : MonoBehaviour
{
    private Animator _animator;

    private void Awake(){
        _animator = GetComponent<Animator>();
    }

    public void AnimationPlay(BossAnimationType bossAnimationType){
        _animator.Play(bossAnimationType.ToString());
    }
}

public enum BossAnimationType{
    Idle
}

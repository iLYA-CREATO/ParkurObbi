using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimState
{ 
    idle,
    walk,
    jump,
    fly
}

public class Animationmachine : MonoBehaviour
{
    [SerializeField] public AnimState animState;
    [SerializeField] private Animator _anim;
    public void Update()
    {
        switch (animState)
        { 
            case AnimState.idle:
                _anim.SetBool("idle", true);

                _anim.SetBool("walk", false);
                _anim.SetBool("fly", false);
                _anim.SetBool("jump", false);

                break; 
            case AnimState.walk:
                _anim.SetBool("walk", true);

                _anim.SetBool("idle", false);
                _anim.SetBool("fly", false);
                _anim.SetBool("jump", false);
                break;
            case AnimState.fly:
                _anim.SetBool("fly", true);

                _anim.SetBool("walk", false);
                _anim.SetBool("idle", false);
                _anim.SetBool("jump", false);
                break;
            case AnimState.jump:
                _anim.SetBool("jump", true);

                _anim.SetBool("walk", false);
                _anim.SetBool("fly", false);
                _anim.SetBool("idle", false);
                break;

        }

    }

    public void ResetAnim()
    {
        _anim.SetBool("jump", false);
        _anim.SetBool("walk", false);
        _anim.SetBool("fly", false);
        _anim.SetBool("idle", false);
    }

}

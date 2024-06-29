using UnityEngine;

public enum AnimState
{ 
    idle,
    walk,
    jump,
    fly,
    fall
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
                _anim.SetBool("fall", false);

                break; 
            case AnimState.walk:
                _anim.SetBool("walk", true);

                _anim.SetBool("idle", false);
                _anim.SetBool("fly", false);
                _anim.SetBool("jump", false);
                _anim.SetBool("fall", false);
                break;
            case AnimState.fly:
                _anim.SetBool("fly", true);

                _anim.SetBool("walk", false);
                _anim.SetBool("idle", false);
                _anim.SetBool("jump", false);
                _anim.SetBool("fall", false);
                break;
            case AnimState.jump:
                _anim.SetBool("jump", true);

                _anim.SetBool("walk", false);
                _anim.SetBool("fly", false);
                _anim.SetBool("idle", false);
                _anim.SetBool("fall", false);
                break;
            case AnimState.fall:
                _anim.SetBool("fall", true);

                _anim.SetBool("walk", false);
                _anim.SetBool("fly", false);
                _anim.SetBool("idle", false);
                _anim.SetBool("jump", false);
                break;

        }

    }

    public void ResetAnim()
    {
        _anim.SetBool("jump", false);
        _anim.SetBool("walk", false);
        _anim.SetBool("fly", false);
        _anim.SetBool("idle", false);
        _anim.SetBool("fall", false);


        bool jump = _anim.GetBool("jump");
        bool walk = _anim.GetBool("walk");
        bool fly = _anim.GetBool("fly");
        bool idle = _anim.GetBool("idle");
        bool fall = _anim.GetBool("fall");

        if (walk == false && fly && jump == false && fall == false)
        {
            _anim.SetBool("idle", true);
        }
    }

}


using System;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Actions
    public static event Action UpdateWalletUIPrizeJump; // Тут мы сообщаем кошельку что в него выгружаем сохранённые деньги

    [Header("Player")]
    public  CharacterController controller;

    [Header("Camera")]
    [SerializeField] private Transform cam;
    
    [Header("Walk")]
     public bool isRun;
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    [SerializeField]  private Vector3 direction;


    [Header("Animation")]
    [SerializeField] private Animationmachine animationmachine;


    [Header("Jump")]
    public bool isJump;

    public bool _iSGround;
    [Header("Награда за прыжок")]
    public int prize; 
    public int ValueJump;

    [SerializeField][Header("Настройка гравитации")] private float gravity;
    [SerializeField][Header("Настройка гравитации прыжка")] private float gravityJump;
    [SerializeField][Header("Настройка силы прыжка")] private float jumpSpeed = 15;
     private Vector3 directionJump;

    [Header("C#")]
    [SerializeField] private TypeControllerPlayer typeControllerPlayer;
    [SerializeField] private Wallet wallet;

    public void Update()
    {
        _iSGround = controller.isGrounded;

        if (direction.magnitude > 0)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }
    }
    public void FixedUpdate()
    {
        if (typeControllerPlayer.WolkPlayer == true)
        {   
            MovePC();
        }

        if (typeControllerPlayer.jumpPlayer == true)
        {
            _JumpPC();
            if (controller.isGrounded == false)
            {
                // Запуск анимации прыжка
                animationmachine.ResetAnim();
                animationmachine.animState = AnimState.jump;
                animationmachine.ResetAnim();
            }

        }
    }

    public void MovePC()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

         direction = new Vector3(hor, 0f, ver).normalized;

        if (direction.magnitude > 0)
        {
            animationmachine.animState = AnimState.walk;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirect = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirect * speed * Time.deltaTime);
        }
        else
        {
            animationmachine.animState = AnimState.idle;
        }
    }

    private void _JumpPC()
    {
        if (controller.isGrounded == true)
        {
            if (Input.GetButton("Jump"))
            {
                directionJump.y = jumpSpeed;
                wallet.Coin += prize; // даём награду игроку за прыжок
                ValueJump++; // Считаем сколько игрок сделал прыжков
                UpdateWalletUIPrizeJump?.Invoke();
                Debug.Log("Space");
            }
        }
        directionJump.y += gravityJump * Time.deltaTime;
        controller.Move(directionJump * Time.deltaTime);


        if (controller.isGrounded == false)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
    }
}

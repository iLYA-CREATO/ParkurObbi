using UnityEngine;

public class AirPlayer : MonoBehaviour
{
    [SerializeField] private float levitationSpeed;

    [Header("Player")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Vector3 flyDirection;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;


    [Header("C#")]
    [SerializeField] private TypeControllerPlayer typeControllerPlayer;

    [Header("Animation")]
    [SerializeField] private Animationmachine animationmachine;

    private void FixedUpdate()
    {
        if (typeControllerPlayer.flyPlayer == true)
        {
            // Работа анимации
            animationmachine.ResetAnim();
            animationmachine.animState = AnimState.fly;
            Fly();
            Move();
        }
    }

    private void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        moveDirection = new Vector3(hor, 0f, ver).normalized;

        if (moveDirection.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirect = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirect * speed * Time.deltaTime);
        }
    }
    private void Fly()
    {
        flyDirection = Vector3.up * levitationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(flyDirection);
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(-flyDirection);
        }
    }
}

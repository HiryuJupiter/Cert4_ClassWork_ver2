using UnityEngine;
using System.Collections;

public class ThirdPersonCMCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Player player;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;

    [Header("Stats")]
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] LayerMask groundLayer;

    //Status
    Vector3 playerVelocity;
    float turnSmoothVelocity;

    //Cache
    float groundCheckDist;
    float sphereCastRadius;

    private void Awake()
    {
        //sphereCastRadius = controller.radius;
        //groundCheckDist = controller.height/2f + 0.1f - sphereCastRadius;

        sphereCastRadius = controller.bounds.extents.x;
        groundCheckDist = controller.bounds.extents.y + 0.1f - sphereCastRadius;
    }

    void Update()
    {
        Jump();
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //Rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                targetAngle,
                ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Movement
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            float moveSpeed = player.playerStats.walkSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = player.playerStats.sprintSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                moveSpeed = player.playerStats.crouchSpeed;
            }

            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded)
        {
            if (playerVelocity.y < 0)
                playerVelocity.y = 0f;

            if (Input.GetKey(KeyCode.Space))
                playerVelocity.y += Mathf.Sqrt(player.playerStats.jumpHeight * -3f * gravity);
        }
        controller.Move(playerVelocity * Time.deltaTime);

        Debug.DrawRay(transform.position, Vector3.down * groundCheckDist, Color.yellow);
    }

    RaycastHit hit;
    bool isGrounded => Physics.SphereCast(transform.position, sphereCastRadius, Vector3.down, out hit, groundCheckDist, groundLayer);
    //bool isGrounded => Physics.Raycast(transform.position, Vector3.down, groundCheckDist, groundLayer);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position - Vector3.down * groundCheckDist, sphereCastRadius);
    }


    void OnGUI()
    {
        //GUI.Label(new Rect(20, 20, 500, 20), "player rot y" + transform.eulerAngles.y);
        //GUI.Label(new Rect(20, 40, 500, 20), "camera rot y" + cam.eulerAngles.y);

        //GUI.Label(new Rect(20, 80, 500, 20), "back atan angle" + Mathf.Atan2(0, -1) * Mathf.Rad2Deg);

        //GUI.Label(new Rect(20, 120, 500, 20), "Input.GetButtonDown(Jump)" + Input.GetButtonDown("Jump"));
        //GUI.Label(new Rect(20, 140, 500, 20), "isgrounded" + controller.isGrounded);
    }
}

/*
 void Update()
        {
            Move1();
            //CalculateDirection();
        }

        void Move1()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            Vector3 moveDir = Vector3.zero;
            if (direction.magnitude >= 0.1f)
            {
                //Rotation
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                //Movement
                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * moveSpeed;
            }
            
            //Jump
            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                moveDir.y += Mathf.Sqrt(jumpHeight * -3f * gravity);
            }

            //Gravity
            moveDir.y += gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
 */


//void CalculateDirection()
//{
//    horizontal = Input.GetAxisRaw("Horizontal");
//    vertical = Input.GetAxisRaw("Vertical");
//    Vector3 direction = new Vector3(horizontal, 0f, vertical);

//    if (direction.magnitude >= 0.1f)
//    {
//        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

//        Rotation(direction, targetAngle);
//        Move(targetAngle);
//    }
//}

//void Rotation(Vector3 direction, float targetAngle)
//{
//    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
//    transform.rotation = Quaternion.Euler(0f, angle, 0f);
//}

//void Move(float targetAngle)
//{
//    //targetAngle = vertical >= 0 ? targetAngle : targetAngle;
//    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
//    controller.Move(moveDir * speed * Time.deltaTime);
//}




/*
 playerLayer = LayerMask.NameToLayer("Player");
        playerLayer = 1 << playerLayer;
        playerLayer = ~playerLayer;

        Debug.Log("ground layer: " + (1 << LayerMask.NameToLayer("Ground")) + ", ground layer: " + groundLayer.value);
 */
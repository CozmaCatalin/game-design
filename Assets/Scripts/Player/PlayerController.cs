using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 150f;
    public float gravityScale = 1f;
    public float rotateSpeed;
 
    public Animator animator;
    public Transform pivot;

    //public Rigidbody playerRigidBody;
    public CharacterController playerController;
    public GameObject playerModel;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //playerRigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, playerRigidBody.velocity.y, Input.GetAxis("Vertical")*moveSpeed);
        //if (Input.GetButtonDown("Jump"))
        //{
        //    playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpForce, playerRigidBody.velocity.z);
        //}

        // moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        if (playerController.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }


        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        playerController.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Active");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Passive");
        }

        // Move the plater in different directions based on camera look direction
        if (h != 0  || v != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed);

        }

        var speed = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
        animator.SetFloat("speedv", speed);
    }
}

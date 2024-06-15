using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public CharacterController con;
    public Animator anim;
    public Rigidbody rb;


    float normalSpeed = 3f; // �ʏ펞�̈ړ����x
    float sprintSpeed = 5f; // �_�b�V�����̈ړ����x
    float jump = 10f;        // �W�����v��
    float gravity = 10f;    // �d�͂̑傫��
    bool jumpMotion = false;
    bool jumpMotion2 = false;

    Vector3 moveDirection = Vector3.zero;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        if  (true)
        {
            float speed = Input.GetButton("Fire3") ? sprintSpeed : normalSpeed;

            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed; 

            if (con.isGrounded)
            {
                moveDirection = moveX;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jump;
                }
            }
            else
            {
               
                moveDirection = moveX + new Vector3(0, moveDirection.y, 0);
                moveDirection.y -= gravity * Time.deltaTime;

            }

          
            anim.SetFloat("MoveSpeed", (moveX).magnitude);

            
            transform.LookAt(transform.position + moveX);

           
            con.Move(moveDirection * Time.deltaTime);
        }
    }
}
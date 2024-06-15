using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

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

            // �ړ����x���擾
            float speed = Input.GetButton("Fire3") ? sprintSpeed : normalSpeed;

            // �J�����̌�������ɂ������ʕ����̃x�N�g��
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // �O�㍶�E�̓��́iWASD�L�[�j����A�ړ��̂��߂̃x�N�g�����v�Z
            // Input.GetAxis("Vertical") �͑O��iWS�L�[�j�̓��͒l
            // Input.GetAxis("Horizontal") �͍��E�iAD�L�[�j�̓��͒l
            // Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //�@�O��i�J������j�@ 
            Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed; // ���E�i�J������j

            // isGrounded �͒n�ʂɂ��邩�ǂ����𔻒肵�܂�
            // �n�ʂɂ���Ƃ��̓W�����v���\��
            if (con.isGrounded)
            {
                moveDirection = moveX;
                //anim.SetBool("JumpMotion2", true);
                //anim.SetBool("JumpMotion", false);
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jump;
                    //anim.SetBool("JumpMotion", true);
                    //anim.SetBool("JumpMotion2", false);
                }
            }
            else
            {
                // �d�͂���������
                moveDirection = moveX + new Vector3(0, moveDirection.y, 0);
                moveDirection.y -= gravity * Time.deltaTime;

            }

            // �ړ��̃A�j���[�V����
            anim.SetFloat("MoveSpeed", (moveX).magnitude);

            // �v���C���[�̌�������͂̌����ɕύX�@
            transform.LookAt(transform.position + moveX);

            // Move �͎w�肵���x�N�g�������ړ������閽��
            con.Move(moveDirection * Time.deltaTime);
        }
    }
}
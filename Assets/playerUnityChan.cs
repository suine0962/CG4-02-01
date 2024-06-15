using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

public class PlayerScript : MonoBehaviour
{

    public CharacterController con;
    public Animator anim;
    public Rigidbody rb;


    float normalSpeed = 3f; // 通常時の移動速度
    float sprintSpeed = 5f; // ダッシュ時の移動速度
    float jump = 10f;        // ジャンプ力
    float gravity = 10f;    // 重力の大きさ
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

            // 移動速度を取得
            float speed = Input.GetButton("Fire3") ? sprintSpeed : normalSpeed;

            // カメラの向きを基準にした正面方向のベクトル
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 前後左右の入力（WASDキー）から、移動のためのベクトルを計算
            // Input.GetAxis("Vertical") は前後（WSキー）の入力値
            // Input.GetAxis("Horizontal") は左右（ADキー）の入力値
            // Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //　前後（カメラ基準）　 
            Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed; // 左右（カメラ基準）

            // isGrounded は地面にいるかどうかを判定します
            // 地面にいるときはジャンプを可能に
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
                // 重力を効かせる
                moveDirection = moveX + new Vector3(0, moveDirection.y, 0);
                moveDirection.y -= gravity * Time.deltaTime;

            }

            // 移動のアニメーション
            anim.SetFloat("MoveSpeed", (moveX).magnitude);

            // プレイヤーの向きを入力の向きに変更　
            transform.LookAt(transform.position + moveX);

            // Move は指定したベクトルだけ移動させる命令
            con.Move(moveDirection * Time.deltaTime);
        }
    }
}
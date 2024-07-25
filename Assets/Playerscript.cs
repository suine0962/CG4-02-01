using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{

    public CharacterController con;
    public Animator anim;
    public GameObject bullet;
    public GameObject gameManager;
    //private GameManagerScript gameManagerScript;

    float normalSpeed = 3f; // 通常時の移動速度
    float sprintSpeed = 5f; // ダッシュ時の移動速度
    //float jump = 10f;        // ジャンプ力
    float gravity = 10f;    // 重力の大きさ
    float bulletTimer = 0;
    Vector3 moveZ;
    Vector3 moveX;

    Vector3 moveDirection = Vector3.zero;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        //gameManagerScript = gameManager.GetComponent<GameManagerScript>();
    }


    void Update()
    {
        //if (gameManagerScript.IsGameOver() == false)
        //{
            // 移動速度を取得
            float speed = Input.GetButton("Fire3") ? sprintSpeed : normalSpeed;

            // カメラの向きを基準にした正面方向のベクトル
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 前後左右の入力（WASDキー）から、移動のためのベクトルを計算
            // Input.GetAxis("Vertical") は前後（WSキー）の入力値
            // Input.GetAxis("Horizontal") は左右（ADキー）の入力値
            moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //　前後（カメラ基準）　 
            moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed; // 左右（カメラ基準）

            // isGrounded は地面にいるかどうかを判定します
            // 地面にいるときはジャンプを可能に
            if (con.isGrounded)
            {
                moveDirection = moveX + moveZ;


                //if (Input.GetButtonDown("Jump"))
                //{
                //    moveDirection.y = jump;
                //}
            }
            else
            {
                // 重力を効かせる
                moveDirection = moveX + moveZ + new Vector3(0, moveDirection.y, 0);
                moveDirection.y -= gravity * Time.deltaTime;

            }

            // 移動のアニメーション
            anim.SetFloat("MoveSpeed", (moveX + moveZ).magnitude);

            // プレイヤーの向きを入力の向きに変更　
            transform.LookAt(transform.position + moveX + moveZ);

            // Move は指定したベクトルだけ移動させる命令
            con.Move(moveDirection * Time.deltaTime);

        }
        //return;
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //gameManagerScript.GameOverStart();
        }
    }

//    private void FixedUpdate()
//    {
//        if (gameManagerScript.IsGameOver())
//        {
//            return;
//        }
//        if (bulletTimer == 0)
//        {
//            //弾発射
//            if (Input.GetKey(KeyCode.Space))
//            {
//                Vector3 pos = transform.position;
//                pos.y += 0.8f;
//                pos.z += 1.0f;

//                Instantiate(bullet, pos, Quaternion.identity);
//                bulletTimer = 1;
//            }
//        }
//        else
//        {
//            bulletTimer++;
//            if (bulletTimer > 20)
//            {
//                bulletTimer = 0;
//            }
//        }
//    }
}
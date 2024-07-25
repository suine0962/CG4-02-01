using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    
    public Rigidbody rb;

    private bool isBlock = true;
    private AudioSource audioSource;
    public GameObject BombParticle;
    float movespeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayPosition = transform.position;
        Vector3 v = rb.velocity;
        float distance = 0.6f;
        

        Ray ray =new Ray(rayPosition, Vector3.down);
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        isBlock = Physics.Raycast(ray, distance);

        if(isBlock==true)
        {
            Debug.DrawRay(rayPosition,Vector3.down * distance, Color.red);
        }

        else
        {
            Debug.DrawRay(rayPosition,Vector3.down*distance, Color.yellow);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            v.x = movespeed;
        }
        else
        {
            v.x = 0.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -movespeed;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            v.y = movespeed;
        }


        rb.velocity = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag=="COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManager.score += 1;

            Instantiate(BombParticle, transform.position, Quaternion.identity);
        }
    }
}                  

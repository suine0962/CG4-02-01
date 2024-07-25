using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

 


        



    }

    // Update is called once per frame
    void Update()
    {
        var playerPosition =Player.transform.position;
        var position=transform.position;
        position.x= playerPosition.x;
        position.y= playerPosition.y+2;
        position.z= playerPosition.z-10;
        transform.position = position;

    }
}

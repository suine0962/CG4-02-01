using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    int[,] map;
    public GameObject block;
    public GameObject Goal;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    public static int score= 0;
    //GameObject[,] field;

    //public GameObject clearText;
    // Start is called before the first frame update
    void Start()
    {


        map = new int[,]{
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1 },
            {1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 ,1, 1, 1, 1, 1 ,1, 1, 1, 1, 1  },
        };

        //field = new GameObject
        //[
        //  map.GetLength(0),
        //  map.GetLength(1)
        //];


        //Screen.SetResolution(1920, 1080, false);

        Vector3 position = Vector3.zero;
        //Instantiate(block, position, Quaternion.identity);



        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                position.x = x;
                position.y = -y + 5;
                if (map[y, x] == 1)
                {
                     Instantiate(block,
                        position,
                        Quaternion.identity);

                }

                if (map[y, x] == 2)
                {
                    Goal.transform.position = position;
                }


                if (map[y, x] == 3)
                {
                   Instantiate(coin, position, Quaternion.identity);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(IsCleard())
        //{
        //    clearText.SetActive(true);
        //}

        scoreText.text = "SCORE" + score;

    }

    //bool IsCleard()
    //{
    //    List<Vector2Int> goals = new List<Vector2Int>();
    //    for (int y = 0; y < map.GetLength(0); y++)
    //    {
    //        for (int x = 0; x < map.GetLength(1); x++)
    //        {
    //            for (int i = 0; i < goals.Count; i++)
    //            {
    //                if (map[y, x] == 2)
    //                {
    //                    goals.Add(new Vector2Int(x, y));

    //                    GameObject f = field[goals[i].y, goals[i].x];
    //                    if (f == null || f.tag != "Box")
    //                    {
    //                        return false;
    //                    }
    //                }
    //            }

    //        }
    //    }
    //    return true;
    //}
}

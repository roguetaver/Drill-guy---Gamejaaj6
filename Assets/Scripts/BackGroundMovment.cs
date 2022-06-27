using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovment : MonoBehaviour
{
    // Start is called before the first frame update
    Controller2D controller;
    Player player;
    Vector3 pos;
    float moveSpeed;


    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<Controller2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        moveSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isMoving)
        {
            pos = new Vector3(1, 0, 0);
            transform.position += pos * controller.direction *moveSpeed*Time.deltaTime;
        }
    }
}

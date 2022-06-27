using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    Animator animator;
    Controller2D controller;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<Controller2D>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.isMoving) {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if(controller.direction == 1)
        {
            animator.SetFloat("Direction", 1);
        }
        else if(controller.direction == -1)
        {
            animator.SetFloat("Direction", -1);
        }

        if (controller.dead)
        {
            animator.SetBool("Death", true);
        }

        if (controller.exitBool)
        {
            animator.SetBool("Exit", true);
        }
    }
}

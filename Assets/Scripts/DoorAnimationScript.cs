using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationScript : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    Controller2D controller;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GameObject.Find("Player").GetComponent<Controller2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.openDoor)
        {
            animator.SetBool("Open", true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask collisionMask;
    Collider2D[] collidersDeath;
    public bool hitCollider;
    Controller2D controller;

    void Start()
    {
        hitCollider = false;
        controller = GameObject.Find("Player").GetComponent<Controller2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(transform.position.x - 0.25f, transform.position.y - 0.4f, transform.position.z);
        collidersDeath = Physics2D.OverlapCircleAll(pos, 0.25f, collisionMask);

        if (collidersDeath.Length > 0)
        {
            controller.direction = 0;
            print("dead");
            controller.dead = true;
        }

        
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = new Vector3(transform.position.x - 0.25f, transform.position.y - 0.4f, transform.position.z);
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pos, 0.3f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask playerSpikesMask;
    public LayerMask playerMask;
    Collider2D[] collidersDeath;
    Vector2 rayOrigin;
    public GameObject particles;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rayOrigin = transform.position;
        collidersDeath = Physics2D.OverlapCircleAll(rayOrigin, 0.5f, playerSpikesMask);


        if (collidersDeath.Length > 0)
        {
            print("morreu");
            Instantiate(particles, transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }

    }

    
    bool CanSeePlayerRight()
    {

        bool val = false;
        float castDist = 3f;
        Vector2 endPos = transform.position + Vector3.right * castDist;

        RaycastHit2D hitPlayer = Physics2D.Linecast(transform.position, endPos, 1 << playerMask);



        if(hitPlayer)
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }


    bool CanSeePlayerLeft()
    {

        bool val = false;
        float castDist = 3f;
        Vector2 endPos = transform.position + Vector3.left * castDist;

        RaycastHit2D hitPlayer = Physics2D.Linecast(transform.position, endPos, 1 << playerMask);



        if (hitPlayer)
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

}

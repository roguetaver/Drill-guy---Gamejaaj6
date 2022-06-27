using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPoint : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    Vector3 pos;


    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(0, Player.transform.position.y, transform.position.z);
        transform.position = pos;
        
    }
}

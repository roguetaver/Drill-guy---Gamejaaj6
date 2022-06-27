using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject estado1;
    public GameObject estado2;
    public bool estado;
    Controller2D controller2d;
    public int NumberOfSwaps;
    public int cont;
    Text SwitchText;
    public GameObject Player;
    public Controller2D controller;
    public GameObject pointsRight;
    public GameObject pointsLeft;
    public bool horizontal;

    void Start()
    {
        estado1 = GameObject.Find("Estado1");
        estado2 = GameObject.Find("Estado2");
        estado = false;
        estado1.SetActive(true);
        estado2.SetActive(false);

        controller2d = GameObject.Find("Player").GetComponent<Controller2D>();
        cont = 0;

        SwitchText = GameObject.Find("Canvas/Crystal/swapsNumber").GetComponent<Text>();
        SwitchText.text = NumberOfSwaps.ToString();

        Player = GameObject.Find("Player");
        pointsRight = GameObject.Find("PointsRight");
        pointsLeft = GameObject.Find("PointsLeft");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.M))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

            if (horizontal)
        {
            if (controller2d.direction == 1)
            {
                pointsRight.SetActive(true);
                pointsLeft.SetActive(false);

            }
            else if (controller2d.direction == -1)
            {
                pointsRight.SetActive(false);
                pointsLeft.SetActive(true);
            }
        }


        if (Input.GetKeyUp(KeyCode.Z))
        {
            if(cont < NumberOfSwaps)
            {
                if (estado)
                {
                    estado1.SetActive(true);
                    estado2.SetActive(false);
                    estado = false;
                }
                else
                {
                    estado1.SetActive(false);
                    estado2.SetActive(true);
                    estado = true;
                }
                cont++;
            }
            
        }
        int num = NumberOfSwaps - cont;
        SwitchText.text = num.ToString();

        if (Input.GetKeyUp(KeyCode.R))
        {
            controller2d.deathCall();
        }

    }

    
}

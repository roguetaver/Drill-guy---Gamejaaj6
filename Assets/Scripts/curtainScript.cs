using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class curtainScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("NextLevel", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeLevel()
    {
        
        animator.SetBool("NextLevel", true);

    }


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

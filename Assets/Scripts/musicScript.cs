using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class musicScript : MonoBehaviour
{
    // Start is called before the first frame update
    private static musicScript original;

    public AudioMixer mixer;
    void Start()
    {

        if (original != this)
        {
            if (original != null)
                Destroy(original.gameObject);
            DontDestroyOnLoad(gameObject);
            original = this;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

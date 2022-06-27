using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    public GameManager gamemanager;
    public bool vertical;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    // Start is called before the first frame update
    void Start()
    {
        print(gamemanager.NumberOfSwaps);
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                     cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }

        if (Input.GetKey(KeyCode.Z) && gamemanager.cont < gamemanager.NumberOfSwaps)
        {
            if (!vertical)
            {
                ShakeCamera(2.5f, 0.1f);
            }
            else
            {
                ShakeCamera(2.5f, 0.1f);
            }
            
        }
        else
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                     cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        }
    }
}

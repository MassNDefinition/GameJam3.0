using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraComponent : MonoBehaviour {
    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 2.0f;

    public CinemachineVirtualCamera vCam;

    void Update()
    {
        if (shakeDuration > 0)
        {
            vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            shakeDuration = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private CinemachineVirtualCamera PlayerCam;
    [SerializeField] private CinemachineVirtualCamera BossCam;

    private int frontPriority = 15;
    private int backPriority = 10;

    private void Awake()
    {
        if(instance != null)
            Debug.LogError("multiple instance is running");
        
        instance = this;
    }

    public void PlayerCamActive()
    {
        PlayerCam.Priority = frontPriority;
        BossCam.Priority = backPriority;
    }

    public void BossCamActive()
    {
        PlayerCam.Priority = backPriority;
        BossCam.Priority = frontPriority;
    }
}

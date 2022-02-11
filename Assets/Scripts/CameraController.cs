using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    //  [SerializeField]  private CinemachineVirtualCamera _cam1;
    //  [SerializeField]  private CinemachineVirtualCamera _cam2;

    public GameObject _cam1;
    public GameObject _cam2;

    public void SwitchCamera()
    {
        _cam1.SetActive(false);
        _cam2.SetActive(true);
        Debug.Log("Camera zoomed in");


    }

}

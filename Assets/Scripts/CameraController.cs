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

    public bool ZoomIn;


    public void SwitchCamera()
    {
        if (!ZoomIn)
        {
            _cam1.SetActive(false);
            _cam2.SetActive(true);
            Debug.Log("Camera zoomed in");
        }
        else
        {
            _cam1.SetActive(true);
            _cam2.SetActive(false);
        }

    }

}

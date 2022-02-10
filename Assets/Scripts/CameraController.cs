using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float panSpeed = 20f;


    public void PanCamera()
    {
        Vector3 camPos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + panSpeed * Time.deltaTime);        

        cam.transform.position = camPos;
    }
}

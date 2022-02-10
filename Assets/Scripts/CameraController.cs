using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float panSpeed = 20f;


    void Update()
    {
        Vector3 camPos = cam.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            camPos.z += panSpeed * Time.deltaTime;
        }

        cam.transform.position = camPos;
    }
}

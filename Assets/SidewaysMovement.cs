using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysMovement : MonoBehaviour
{
    [SerializeField] private float _limitX = 5f;
    [SerializeField] private float _xSpeed = 0.05f;
    [SerializeField] private float _sensitivity = 50f;


    public bool IsControllable;
    private float _lastXPoint;


    public void Initialize()
    {
        IsControllable = true;
    }

    void Update()
    {
        float deltaX = 0;
        float newXPos = 0;

        newXPos = transform.position.x + deltaX * _xSpeed * _sensitivity;



        if (IsControllable == false)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            deltaX = Input.GetAxis("Mouse X");
        }

        else if (Input.GetMouseButton(0))
        {
            Vector3 newPos = new Vector3(newXPos, transform.position.y, transform.position.z);
            transform.position = newPos;

        }
    }

    private float ClampX(float newXPos)
    {
        return Mathf.Clamp(newXPos, -_limitX, _limitX);
    }

    public void Dispose()
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action MovementCompleted;
    public event Action MovementCompletedLocal;

    [SerializeField] private float _runSpeed = 5;
    [SerializeField] private float _limitX = 5;
    [SerializeField] private float _limitZ = 20;
    [SerializeField] private float _xspeed = 0.05f;

    [SerializeField] private float _sensitivity = 5f;
    [SerializeField] private Animator _playerAnim;

    public bool IsControllable;

    public void Initialize()
    {
        IsControllable = false;
    }
    public void StartRunning()
    {
        StartCoroutine(Running());
    }

    IEnumerator Running()
    {
        float newX = 0;


        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsControllable = true;
                _playerAnim.SetBool("Run", true);
            }
            
            if(IsControllable == false)
            {
                yield return null;
                continue;
            }

            if (Input.GetMouseButton(0))
            {
                float DeltaX = Input.GetAxis("Mouse X");

                newX = transform.position.x + DeltaX * _xspeed * _sensitivity;
                newX = Mathf.Clamp(newX, -_limitX, _limitX);
            }

            if (transform.position.z >= _limitZ)
            {
                FinishRunning();
                yield break;

            }

            Vector3 newPos = new Vector3(newX, transform.position.y, transform.position.z + _runSpeed * Time.deltaTime);
            transform.position = newPos;

            yield return null;
        }
    }
    private void FinishRunning()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _limitZ);
        _playerAnim.SetBool("Run", false);

        IsControllable = false;

        //  transform.eulerAngles = new Vector3(0, 0, 0);

        transform.DOLookAt(new Vector3(0, 0, 0), 0.5f).OnComplete(() => 
        { 
            _playerAnim.SetTrigger("Dance");
            MovementCompleted.Invoke(); //all events are called via Invoke();
            MovementCompletedLocal.Invoke(); 
        } );              //() => { }

        //  yield return new WaitForSeconds(1);  only in coroutine


    }


}
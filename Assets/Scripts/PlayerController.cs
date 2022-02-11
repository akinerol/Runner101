using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action MovementCompleted;
    public event Action MovementCompletedLocal;
    public event Action MidpointReachedLocal;
    public bool DidFinishMiniGame;                      //Meteor Explode game


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
        DidFinishMiniGame = false;
    }
    public void StartRunning()
    {
        StartCoroutine(Running());
    }

    IEnumerator Running()
    {
        float currentPosX = 0;


        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsControllable = true;
                _playerAnim.SetBool("Run", true);
            }

            if (IsControllable == false)
            {
                yield return null;
                continue;
            }

            if (Input.GetMouseButton(0))
            {
                float DeltaX = Input.GetAxis("Mouse X");

                currentPosX = transform.position.x + DeltaX * _xspeed * _sensitivity;
                currentPosX = Mathf.Clamp(currentPosX, -_limitX, _limitX);
            }
            float currentPosZ = transform.position.z;

            if (currentPosZ >= _limitZ / 2 && !DidFinishMiniGame)                                            //Player is at the halfway
            {

                transform.position = new Vector3(transform.position.x, transform.position.y, currentPosZ);

                _playerAnim.SetBool("Run", false);

                MidpointReachedLocal.Invoke();             
                yield break;
            }



                if (currentPosZ >= _limitZ)
            {
                FinishRunning();
                yield break;

            }


            Vector3 currentPos = new Vector3(currentPosX, transform.position.y, transform.position.z + _runSpeed * Time.deltaTime);         //yeni bir fonksiyona atamadim??????????? currentPosX yuzunden
            transform.position = currentPos;

            yield return null;
        }
    }



    private void FinishRunning()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _limitZ);
        _playerAnim.SetBool("Run", false);

        IsControllable = false;

        transform.DOLookAt(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
        {
            _playerAnim.SetTrigger("Dance");
            MovementCompleted.Invoke(); //all events are called via Invoke();
            MovementCompletedLocal.Invoke();
        });              //() => { }
        //  yield return new WaitForSeconds(1);  only in coroutine
    }
}
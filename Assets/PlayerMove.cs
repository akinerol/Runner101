using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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
    void Start()
    {

        StartCoroutine(Running());
    }




    IEnumerator Running()
    {
        float newX = 0;
        float DeltaX = 0;


        while (IsControllable == true)
        {

            if (Input.GetMouseButton(0))
            {
                IsControllable = true;


                DeltaX = Input.GetAxis("Mouse X");
                _playerAnim.SetBool("Run", true);


                newX = transform.position.x + DeltaX * _xspeed * _sensitivity;
                newX = Mathf.Clamp(newX, -_limitX, _limitX);

                Vector3 newPos = new Vector3(newX, transform.position.y, transform.position.z + _runSpeed * Time.deltaTime);
                transform.position = newPos;
            }

           // float PosZ = transform.position.z;

            if (transform.position.z >= _limitZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _limitZ);
                _playerAnim.SetBool("Run", false);

              //  transform.eulerAngles = new Vector3(0, 0, 0);
                transform.DOLookAt(new Vector3(0, 0, 0), 2f);
                yield return new WaitForSeconds(2);

                 _playerAnim.SetTrigger("Dance");

                yield break;
            }



            yield return null;

        }

    }

}

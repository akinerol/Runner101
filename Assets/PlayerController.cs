using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _limitX = 5f;
    [SerializeField] private float _xSpeed = 0.05f;
    [SerializeField] private float _sensitivity = 50f;
    [SerializeField] private float _limitZ = 20f;
    [SerializeField] private Animator _playerAnim;          // GetComponent ile çağırmak yerine inspector'dan animator atandı.

    public bool IsControllable;

    public void Initialize()
    { }


    void Start()
    {
        StartCoroutine(PlayerMove());
    }

    IEnumerator PlayerMove()
    {
        float posZ = 0;



        while (IsControllable == true)
        {
           // posZ = transform.position.z + _runSpeed * Time.deltaTime;

            if (Input.GetMouseButton(0))
            {
                posZ = transform.position.z + _runSpeed * Time.deltaTime;

                float deltaX = 0;
                float newX = 0;

                deltaX = Input.GetAxis("Mouse X");
                _playerAnim.SetBool("Run", true);

                newX = transform.position.x + deltaX * _xSpeed * _sensitivity;
                newX = Mathf.Clamp(newX, -_limitX, _limitX);

                Vector3 newPos = new Vector3(newX, transform.position.y, posZ);
                transform.position = newPos;


                if (posZ <= _limitZ)
                {
                    newPos = new Vector3(transform.position.x, transform.position.y, _limitZ);
                    transform.position = newPos;
                    _playerAnim.SetBool("Run", false);
                    _playerAnim.SetTrigger("Dance");
                }
                yield break;
            }
            yield return null;
        }
    }
}
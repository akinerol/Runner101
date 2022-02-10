using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    private GameObject _meteor = null;


    [SerializeField] private Rigidbody _meteorRb;

    // Start is called before the first frame update
    void Start()
    {
 

        PlayerController.MovementCompleted += OnMovementCompleted;


        Instantiate(_meteor, transform.position, Quaternion.identity);
    }

    private void OnMovementCompleted()
    {
        StartCoroutine(StartMeteor());

    }
    private IEnumerator StartMeteor()
    {
        _meteorRb.AddForce(Vector3.down * Random.Range(10, 15), ForceMode.Force);
        transform.position = new Vector3(Random.Range(-5, 5), 10);

        yield return null;
    }


}

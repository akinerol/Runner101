using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private List<GameObject> _meteorites;                  //for meteorites
    [SerializeField] private GameObject _meteoritePrefab;


    private Rigidbody _targetRb;
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        
    }

  
    private void OnMouseDown()
    {
        Destroy(gameObject);


    }


}

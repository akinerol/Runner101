using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public event Action MeteorsExpodedLocal;


    [SerializeField] private Transform _explosionSource;
    [SerializeField] private List<GameObject> _meteorites;
    [SerializeField] private GameObject _meteoritePrefab;



    private void OnMouseDown()
    {
        MeshRenderer MeshComponent = gameObject.GetComponent<MeshRenderer>();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        
            foreach (GameObject meteorite in _meteorites)
            {
                meteorite.SetActive(true);
                meteorite.GetComponent<Rigidbody>().AddExplosionForce(250, _explosionSource.position, 25);
            }

        MeteorsExpodedLocal.Invoke();
    }
}


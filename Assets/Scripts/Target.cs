using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private List<GameObject> _meteorites;
    [SerializeField] private GameObject _meteoritePrefab;



    void Start()
    {

    }

   

    private void OnMouseDown()
    {
        MeshRenderer MeshComponent = gameObject.GetComponent<MeshRenderer>();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Vector3 ExpPos = this.transform.position;
      
            foreach (GameObject meteorite in _meteorites)
            {
            meteorite.SetActive(true);

          //  meteorite.GetComponent<Rigidbody>().AddExplosionForce(5, ExpPos, 2, 0);

           // Debug.Log("Meteors exploded");
            }

        
        

    }
}
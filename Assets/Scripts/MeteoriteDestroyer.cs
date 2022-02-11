using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteDestroyer : MonoBehaviour
{
    public ParticleSystem Particle;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Meteorite")
        {
            Destroy(col.gameObject);

          Particle = GetComponent<ParticleSystem>();
          //Instantiate(Particle, transform.position, transform.rotation);
        }
    }
}

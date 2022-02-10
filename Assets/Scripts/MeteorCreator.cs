using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour
{
    // public static event Action MeteorDestroyed;


    private List<GameObject> _meteors;
    [SerializeField] private GameObject _meteorPrefab;

    private int _meteorCount = 5;

    private void Start()
    {
        
    }


    public void CreateMeteors()
    {
        StartCoroutine(StartMeteor());

    }
    private IEnumerator StartMeteor()
    {
        yield return new WaitForSeconds(2);

        _meteors = new List<GameObject>();

        for (int i = 0; i < _meteorCount; i++)
        {
            GameObject meteor = Instantiate(_meteorPrefab.gameObject, new Vector3(Random.Range(-5, 5), Random.Range(10, 15), Random.Range(25, 30)), Quaternion.identity);
            _meteors.Add(meteor);
        };
        

    }
}



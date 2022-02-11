using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour
{

    private List<GameObject> _meteors;
    [SerializeField] private GameObject _meteorPrefab;

    private int _meteorCount = 5;
    private int _randomTime;


    public void CreateMeteors()
    {
        Debug.Log("meteors are created");
        StartCoroutine(SpawnMeteor());

    }
    private IEnumerator SpawnMeteor()
    {

        yield return new WaitForSeconds(2);

        _meteors = new List<GameObject>();

        for (int i = 0; i < _meteorCount; i++)
        {
            GameObject meteor = Instantiate(_meteorPrefab.gameObject, new Vector3(Random.Range(-5, 5), Random.Range(8, 10), Random.Range(30, 35)), Quaternion.identity);
            _meteors.Add(meteor);

            _randomTime = Random.Range(0, 3);
            yield return new WaitForSeconds(_randomTime);
        }
    }
}



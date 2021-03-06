using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorCreator : MonoBehaviour
{
    public event Action AllMeteorsExploded;

    private List<GameObject> _meteors;
    [SerializeField] private GameObject _meteorPrefab;

    private int _meteorCount = 5;
    private int _randomTime;
    private int _meteorsExploded = 0;

    public void OnMeteorExpoloded()
    {
        _meteorsExploded++;

        if (_meteorsExploded >= _meteorCount)
        {
            AllMeteorsExploded?.Invoke();           //tum meteorlar explode olduktan sonra GameController a invoke gonderilir.
        }
    }
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
            meteor.GetComponent<Target>().MeteorsExpodedLocal += OnMeteorExpoloded;
            _meteors.Add(meteor);

            _randomTime = Random.Range(0, 3);
            yield return new WaitForSeconds(_randomTime);
        }
    }
}



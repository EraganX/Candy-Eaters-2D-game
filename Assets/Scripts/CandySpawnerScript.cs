using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawnerScript : MonoBehaviour
{
    [SerializeField] private float _maxX;
    [SerializeField] [Range(0,5)] private float _spawnIntervel;

    [SerializeField] private GameObject[] _candyPrefab;

    public static CandySpawnerScript Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    private void Start()
    {
        StartSpawningCandy();
    }

    void SpawnCandy()
    {
        int randomPrefab = Random.Range(0,_candyPrefab.Length);
        float randomPositionX =Random.Range(-_maxX,_maxX);
        Vector3 randomPosition = new Vector3(randomPositionX,transform.position.y,transform.position.z);
        Instantiate(_candyPrefab[randomPrefab], randomPosition, Quaternion.identity);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(_spawnIntervel);
        }
    }

    public void StartSpawningCandy()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandy()
    {
        StopCoroutine("SpawnCandies");
    }
}

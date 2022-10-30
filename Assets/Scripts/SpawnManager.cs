using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject _player;

    public bool StopSpawning;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
      StopSpawning = false;
}

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnRoutine()
    {
        //while (_player.activeInHierarchy)
        while (!StopSpawning)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(UnityEngine.Random.Range(-13f, 13f), 7, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(1.0f);
        }
    }


    public void OnPlayersDeath()
    {
        StopSpawning = true;
    }
}


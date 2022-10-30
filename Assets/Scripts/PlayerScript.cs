using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    private float _speed = 8;
    [SerializeField]
    private GameObject _laserPrefab;
    float horMax = 13;
    private float _canFire = -1;
    private float _fireRate = 0.25f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if(_spawnManager == null){
            Debug.LogError("SPMAnager is nlll");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }


    private void CalculateMovement()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        
        float yMax = 6;
        float yMin = -4;
        Vector3 direction = new Vector3(horInput, verInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = Math.Abs(transform.position.x) > horMax ? new Vector3(-transform.position.x, transform.position.y, 0) : transform.position;
        transform.position = transform.position.y >= yMax ? new Vector3(transform.position.x, yMax, 0) : transform.position;
        transform.position = transform.position.y <= yMin ? new Vector3(transform.position.x, yMin, 0) : transform.position;
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;
        if (_lives < 1)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        // this.gameObject.SetActive(false);

        Destroy(gameObject);
        _spawnManager.OnPlayersDeath();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 8 * Time.deltaTime);

        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}

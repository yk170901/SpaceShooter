using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-13f, 13f), 7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 4 * Time.deltaTime);
        //if bottom respawn at top
        // ransdomw cx
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(-13f, 13f), 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerScript player = other.transform.GetComponent<PlayerScript>();

            if (player != null)
                player.Damage();

            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

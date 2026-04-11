using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform spawner;
    float health = 4f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "edge")
        {
            health -= 1;
        }
        if (health == 0)
        {
            transform.position = spawner.position;
            health = 4f;
            SceneManager.LoadScene("Game-Over");
        } 
        if (collision.gameObject.tag == "edge")
        {
            transform.position = spawner.position;
            rb.linearVelocity = Vector3.zero;
        }
    }

    public float Health()
    {
        return health;
    }
}

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform spawner;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lava")
        {
            transform.position = spawner.position;
            rb.linearVelocity = Vector3.zero;
        } else if (collision.gameObject.tag == "edge")
        {
            transform.position = spawner.position;
            rb.linearVelocity = Vector3.zero;
        }
    }
}

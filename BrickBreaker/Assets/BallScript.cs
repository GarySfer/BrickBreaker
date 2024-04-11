using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        if(!inPlay) {
            transform.position = paddle.position;
        }

        if(Input.GetButtonDown("Jump") && !inPlay) {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("bottom")) {
            Debug.Log("Bajo jajo");
            rb.velocity = Vector2.zero;
            inPlay = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("brick")) {
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 0.5F);
            Destroy(other.gameObject);
        }
    }
}

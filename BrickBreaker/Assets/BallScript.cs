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
    public GameManager gm;
    public Transform extraLifePowerup;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {

        if (gm.gameover) {
            return;
        }
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
            gm.UpdateLives(-1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("brick")) {
            BrickScript brickScript = other.gameObject.GetComponent<BrickScript>();
            if(brickScript.hitsToBreak > 1) {
                brickScript.BreakBrick();
            } else {

            


                int randomChance = Random.Range(1,101);

                if(randomChance < 10) {
                    Instantiate(extraLifePowerup,other.transform.position, other.transform.rotation);
                }

                Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 0.5F);

                gm.UpdateScore(brickScript.points);
                gm.UpdateBrickAmount();
            
                Destroy(other.gameObject);
            }
        }
    }
}

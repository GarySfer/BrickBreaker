using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaddleScript : MonoBehaviour {

    public float speed;
    public float leftScreenEdge;
    public float rightScreenEdge;
    public GameManager gm;
    
    void Start() {
        leftScreenEdge = -7.6F;
        rightScreenEdge = 7.6F;
    }

    void Update() {
        if (gm.gameover) {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.down * horizontal * Time.deltaTime * speed);
        if(transform.position.x < leftScreenEdge) {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
        if(transform.position.x > rightScreenEdge) {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
    }
}

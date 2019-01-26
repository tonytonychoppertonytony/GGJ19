using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float moveSpeed = 7f;

    Rigidbody2D rb;

    Player_movement target;
    Vector2 moveDirection;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player_movement>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
       if (col.gameObject.name.Equals("Player_1"))
        {
            Debug.Log("Hit!");
            GameControlScript.health -= 1;
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "inviswall")
        {
            Destroy(gameObject);
        }
	}
}

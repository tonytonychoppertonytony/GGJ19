using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

    private Rigidbody2D rb2d4;
    private bool isJumping = false;

    // Use this for initialization1
    void Start () {
        rb2d4 = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        int randomNumber = Random.Range(99, 100);
       // print(randomNumber);

        if (randomNumber < 100 && isJumping == false)
        {
            rb2d4.AddForce(new Vector2(0, 5000));
            isJumping = true;
            print("JUM");
        } 
       
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "invisiwall")
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }

    }
}

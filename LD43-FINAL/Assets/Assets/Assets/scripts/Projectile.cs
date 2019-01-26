using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector2 target;
    public float speed;
    

    void Start()
    {
       // target = new Vector2(100000000, 0);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
       
        
        if (coll.gameObject.tag == "inviswall")
        {
        Destroy(gameObject);
        }
        
    }
}

    

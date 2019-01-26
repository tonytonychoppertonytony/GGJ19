using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeChase : MonoBehaviour
{

    public float speed;
    public bool hasFound;
    private Transform target;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player_1").GetComponent<Transform>();

        //Makes the enemy find the player object
    }

    // Update is called once per frame
    void Update()
    {
        float Direction = Mathf.Sign(target.position.x - transform.position.x);

        if (Vector3.Angle(transform.right, target.position - transform.position) < 22.5)
        {
            Debug.Log("I'm seeing the player");
            hasFound = true;
        }

        if (hasFound == true)
        {
            Vector2 MovePos = new Vector2(transform.position.x + Direction * speed,  transform.position.y);

            transform.position = MovePos;
        }

        Vector2 moveRight = new Vector2(1 * speed, 0);
        transform.position = moveRight;


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player_1")
        {
            hasFound = true;

        }
        else
        {
            hasFound = false;
        }
    }


}

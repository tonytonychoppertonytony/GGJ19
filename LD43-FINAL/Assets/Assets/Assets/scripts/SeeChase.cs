using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeChase : MonoBehaviour
{

    public float speed;
    public float range;
    public float patrolSpeed;
    public float distance;
    public bool hasFound = false;
    private Transform target;
    private Rigidbody2D enermyrb2d;

    private bool movingRight = true;
    private bool movingLeft = false;
    public Transform groundDetection;

    // Use this for initialization
    void Start()
    {

        enermyrb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player_1").GetComponent<Transform>();

        //Makes the enemy find the player object
    }

    // Update is called once per frame
    void Update()
    {
        float Direction = Mathf.Sign(target.position.x - transform.position.x);

        if (Vector3.Angle(transform.right, target.position - transform.position) < 22.5 && Vector2.Distance(transform.position, target.position) < range)
        {
            Debug.Log("I'm seeing the player");
            hasFound = true;
        }

        if (hasFound == true)
        {
            Vector2 MovePos = new Vector2(transform.position.x + Direction * speed,  transform.position.y);

            transform.position = MovePos;
        }

        if (hasFound == false)
        {
            if (movingRight == true)
            {
                transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
            }
           else
            {
                transform.Translate(Vector2.left * -patrolSpeed * Time.deltaTime);
            }
        }
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                movingLeft = true;
                print("moving left");
            } 
            else
            {
               transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                movingLeft = false;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "wall")
        {
            if (movingRight == true)
            {
                movingLeft = true;
                movingRight = false;
            }
            if (movingRight == false)
            {
                movingLeft = false;
                movingRight = true;
            }
        }

        if (coll.gameObject.tag == "Player_1")
        {
            enermyrb2d.AddForce(new Vector2(300, 300));
        }
    }


}

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

    private bool movingRight;
    private bool movingLeft = false;
    public bool switchW = false;
    public Transform groundDetection;

    // Use this for initialization
    void Start()
    {

        enermyrb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player_1").GetComponent<Transform>();
        movingRight = true;

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
            if (movingRight == false)
            {
                transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
                print("left");

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
                //print("moving left");
            } 
            else
            {
               transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                movingLeft = false;
            }
        }

        if (switchW == true && movingRight == true)
            {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
            switchW = false;
            //print("moving left");
        }
        if (switchW == true && movingRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = false;
            switchW = false;
            //print("moving left");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "wall")
        {
            switchW = true;
            print("ech");
        }

        if (coll.gameObject.tag == "Player_1")
        {
            enermyrb2d.AddForce(new Vector2(300, 300));
        }
        if (coll.gameObject.tag == "enemy")
        {

            switchW = true;
        
        }
    }


}

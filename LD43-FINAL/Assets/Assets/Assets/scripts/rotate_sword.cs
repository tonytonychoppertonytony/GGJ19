using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_sword : MonoBehaviour {

    Rigidbody2D rb2d;

    private Transform target;

    void start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }  

    void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        target = GameObject.FindGameObjectWithTag("Player_1").GetComponent<Transform>();
        transform.position = target.transform.position;
    }
}

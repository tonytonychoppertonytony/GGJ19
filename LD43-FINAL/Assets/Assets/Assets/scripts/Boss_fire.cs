using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_fire : MonoBehaviour {

    
    public GameObject bullet;

    public float fireRate;
    float nextFire;
    public float range;
    private Transform target;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player_1").GetComponent<Transform>();
        fireRate = 1f;
        nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, target.position) < range)
            {
            CheckIfTimeToFire();
        }
        
	}

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}

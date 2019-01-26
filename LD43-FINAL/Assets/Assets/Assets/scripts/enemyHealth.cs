using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

    public static int maxHealth;
    public int currentHealth = maxHealth;
    public GameObject wall, wall2, wall3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(wall);
            Destroy(wall2);
            Destroy(wall3);
        }
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Sword")
        {
            currentHealth = currentHealth - 25;
        }
        if (coll.gameObject.tag == "player_bullet")
        {
            currentHealth = currentHealth - 50;

        }
    }
}

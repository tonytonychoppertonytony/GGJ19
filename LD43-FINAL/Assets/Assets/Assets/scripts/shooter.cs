using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour {


    public GameObject bullet;
    private Transform playerPos;
    public static int ammo;
    private Transform target;
    private float offset;
    private int BF;
    public GameObject Ammo1, Ammo2, Ammo3, Ammo4, Ammo5, Ammo6, Ammo7, Ammo8, Ammo9, Ammo10;

    // Use this for initialization
    void Start () {
        playerPos = GetComponent<Transform>();
        ammo = 5;
        Ammo1.gameObject.SetActive(true);
        Ammo2.gameObject.SetActive(true);
        Ammo3.gameObject.SetActive(true);
        Ammo4.gameObject.SetActive(true);
        Ammo5.gameObject.SetActive(true);
        Ammo6.gameObject.SetActive(true);
        Ammo7.gameObject.SetActive(true);
        Ammo8.gameObject.SetActive(true);
        Ammo9.gameObject.SetActive(true);
        Ammo10.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        target = GameObject.FindGameObjectWithTag("Player_1").GetComponent<Transform>();
        offset = transform.position.x - target.position.x;
        if (offset < 0)
        {
            BF = -1;
        }
        if (offset > 0)
        {
            BF = 1;
        }
        if (ammo > 10)
        {
            ammo = 10;
        }
    if (ammo  > 0) {         
        if (Input.GetMouseButtonDown(0))
         {
           Instantiate(bullet, playerPos.position * BF, Quaternion.identity);
                ammo = ammo - 1;
                print("bulletshot");
         }
        }

    if (ammo == 10)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(true);
            Ammo4.gameObject.SetActive(true);
            Ammo5.gameObject.SetActive(true);
            Ammo6.gameObject.SetActive(true);
            Ammo7.gameObject.SetActive(true);
            Ammo8.gameObject.SetActive(true);
            Ammo9.gameObject.SetActive(true);
            Ammo10.gameObject.SetActive(true);
        }
    if (ammo == 9)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(true);
            Ammo4.gameObject.SetActive(true);
            Ammo5.gameObject.SetActive(true);
            Ammo6.gameObject.SetActive(true);
            Ammo7.gameObject.SetActive(true);
            Ammo8.gameObject.SetActive(true);
            Ammo9.gameObject.SetActive(true);
            Ammo10.gameObject.SetActive(false);
        }
    if (ammo == 8)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(true);
            Ammo4.gameObject.SetActive(true);
            Ammo5.gameObject.SetActive(true);
            Ammo6.gameObject.SetActive(true);
            Ammo7.gameObject.SetActive(true);
            Ammo8.gameObject.SetActive(true);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
    if (ammo == 7)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(true);
            Ammo4.gameObject.SetActive(true);
            Ammo5.gameObject.SetActive(true);
            Ammo6.gameObject.SetActive(true);
            Ammo7.gameObject.SetActive(true);
            Ammo8.gameObject.SetActive(false);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
    if (ammo == 6)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(true);
            Ammo4.gameObject.SetActive(true);
            Ammo5.gameObject.SetActive(true);
            Ammo6.gameObject.SetActive(true);
            Ammo7.gameObject.SetActive(false);
            Ammo8.gameObject.SetActive(false);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
    if(ammo == 5)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(true);
            Ammo4.gameObject.SetActive(true);
            Ammo5.gameObject.SetActive(true);
            Ammo6.gameObject.SetActive(false);
            Ammo7.gameObject.SetActive(false);
            Ammo8.gameObject.SetActive(false);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
    if (ammo == 4)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(true);
            Ammo4.gameObject.SetActive(true);
            Ammo5.gameObject.SetActive(false);
            Ammo6.gameObject.SetActive(false);
            Ammo7.gameObject.SetActive(false);
            Ammo8.gameObject.SetActive(false);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
    if (ammo == 3)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(true);
            Ammo4.gameObject.SetActive(false);
            Ammo5.gameObject.SetActive(false);
            Ammo6.gameObject.SetActive(false);
            Ammo7.gameObject.SetActive(false);
            Ammo8.gameObject.SetActive(false);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
    if (ammo == 2)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(true);
            Ammo3.gameObject.SetActive(false);
            Ammo4.gameObject.SetActive(false);
            Ammo5.gameObject.SetActive(false);
            Ammo6.gameObject.SetActive(false);
            Ammo7.gameObject.SetActive(false);
            Ammo8.gameObject.SetActive(false);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
    if (ammo == 1)
        {
            Ammo1.gameObject.SetActive(true);
            Ammo2.gameObject.SetActive(false);
            Ammo3.gameObject.SetActive(false);
            Ammo4.gameObject.SetActive(false);
            Ammo5.gameObject.SetActive(false);
            Ammo6.gameObject.SetActive(false);
            Ammo7.gameObject.SetActive(false);
            Ammo8.gameObject.SetActive(false);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
    if (ammo == 0)
        {
            Ammo1.gameObject.SetActive(false);
            Ammo2.gameObject.SetActive(false);
            Ammo3.gameObject.SetActive(false);
            Ammo4.gameObject.SetActive(false);
            Ammo5.gameObject.SetActive(false);
            Ammo6.gameObject.SetActive(false);
            Ammo7.gameObject.SetActive(false);
            Ammo8.gameObject.SetActive(false);
            Ammo9.gameObject.SetActive(false);
            Ammo10.gameObject.SetActive(false);
        }
     
    }

}

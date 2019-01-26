using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{

    public float speed = 100;             //Floating point variable to store the player's movement speed.
    public float Stamina = 10.0f;
    public bool isJumping;
    public bool isCrouching;
    private bool launch;
    public bool inDoorOne = false;
    public float MaxStamina = 10.0f;
    private float StaminaRegenTimer = 0.0f;//the timer to count the delay
    private const float StaminaDecreasePerFrame = 7.0f;
    private const float StaminaIncreasePerFrame = 10.0f;
    private const float StaminaTimeToRegen = 1.0f; //the delay to regen stamina
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public GameObject Stamina1, Stamina2, Stamina3, Stamina4, Stamina5;
    public bool flipX;
    private SpriteRenderer mySpriteRenderer;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        Stamina1.gameObject.SetActive(true);
        Stamina2.gameObject.SetActive(true);
        Stamina3.gameObject.SetActive(true);
        Stamina4.gameObject.SetActive(true);
        Stamina5.gameObject.SetActive(true);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //new level
        if (Input.GetKey(KeyCode.E)){
            if (inDoorOne == true)
            {
                SceneManager.LoadScene("movement");
                Time.timeScale = 1;
            }
        }


        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb2d.AddForce(new Vector2(0, 3000));
            isJumping = true;
        }
        if (launch == true)
        {
            rb2d.AddForce(new Vector2(0, 300));
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            speed = 75;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            speed = 150;
        }

        //Store the current vertical input in the float moveVertical.
        // float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        if (moveHorizontal < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        if (moveHorizontal > 0)
        {
            mySpriteRenderer.flipX = false;
        }

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        bool isRunning = Input.GetKey(KeyCode.LeftShift); //creates a boolean if left shift is held
        if (isRunning && Stamina > 0) //bool is true and stamina is above 0
        {
            speed = 300;
            Stamina = Mathf.Clamp(Stamina - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina); //stamina decreases
            StaminaRegenTimer = 0.0f; //regen timer is set to 0 so you don't regen stamina
        }
        else if (Stamina < MaxStamina)
        {
            speed = 150;
            if (StaminaRegenTimer >= StaminaTimeToRegen) //once the regen timer (below) is above the set time to regen then stamina increases
                Stamina = Mathf.Clamp(Stamina + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, MaxStamina); 
            else
                StaminaRegenTimer += Time.deltaTime; //stamina regentimer starts to go up
        }

        if (Stamina <= 10 && Stamina > 8)
        {
            Stamina1.gameObject.SetActive(true);
            Stamina2.gameObject.SetActive(true);
            Stamina3.gameObject.SetActive(true);
            Stamina4.gameObject.SetActive(true);
            Stamina5.gameObject.SetActive(true);
        }
        else if (Stamina <= 8 && Stamina > 6)
        {
            Stamina1.gameObject.SetActive(true);
            Stamina2.gameObject.SetActive(true);
            Stamina3.gameObject.SetActive(true);
            Stamina4.gameObject.SetActive(true);
            Stamina5.gameObject.SetActive(false);
        }
        else if (Stamina <= 6 && Stamina > 4)
        {
            Stamina1.gameObject.SetActive(true);
            Stamina2.gameObject.SetActive(true);
            Stamina3.gameObject.SetActive(true);
            Stamina4.gameObject.SetActive(false);
            Stamina5.gameObject.SetActive(false);
        }
        else if (Stamina <= 4 && Stamina > 2)
        {
            Stamina1.gameObject.SetActive(true);
            Stamina2.gameObject.SetActive(true);
            Stamina3.gameObject.SetActive(false);
            Stamina4.gameObject.SetActive(false);
            Stamina5.gameObject.SetActive(false);
        }
        else if (Stamina <=2 && Stamina > 0)
        {
            Stamina1.gameObject.SetActive(true);
            Stamina2.gameObject.SetActive(false);
            Stamina3.gameObject.SetActive(false);
            Stamina4.gameObject.SetActive(false);
            Stamina5.gameObject.SetActive(false);
        }
        else if (Stamina <= 0)
        {
            Stamina1.gameObject.SetActive(false);
            Stamina2.gameObject.SetActive(false);
            Stamina3.gameObject.SetActive(false);
            Stamina4.gameObject.SetActive(false);
            Stamina5.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "inviswall")
        {
            isJumping = false;
            launch = false;
        }

        if (coll.gameObject.tag == "head")
        {
            launch = true;
            print("no");
        }

        if (coll.gameObject.tag == "Door1")
        {
            inDoorOne = true;
            print("in door one true");
        }
        else {
            print("out door1");
        }

    }


}
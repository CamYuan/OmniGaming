 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

    private int playerSpeed = 5;
    private int direction = 1;
    private float vectorY = 0.0f;

    public float jumpSpeed = 10.0f;
    public float forceY = 0;
    private float invertGrav;
    public float gravity = 20.0F;
    public float gravityForce = 3.0f;
    public float airTime = 2f;

    public int curHealth = 0;
    public int maxHealth = 2;

    private DeathMenu Death;
    private BoxCollider2D controller;
    public BoxCollider2D ground;


    //knockback testing
    //public Rigidbody2D rb2D;


    // Use this for initialization
    void Start () {
        Death = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DeathMenu>();
        invertGrav = gravity * airTime;
        controller = GetComponent<BoxCollider2D>();
        //knockback testing
        //rb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Touch_Move_Player();
        Keyboard_Move_Player();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * playerSpeed, vectorY);
    }

    void Touch_Move_Player()
    {
        if (controller.IsTouching(ground))
        {
            forceY = 0;
            invertGrav = gravity * airTime;
            if (Input.touchCount > 0 || Input.GetKey(KeyCode.Space))
            {
                forceY = jumpSpeed;
            }
        }
        else
        {
            if ((Input.touchCount > 0 || Input.GetKey(KeyCode.Space)))
            {
                forceY -= gravity * Time.deltaTime;
            }
            else
            {
                forceY -= gravity * Time.deltaTime * 2;
            }
        }
        vectorY = forceY;
    }

    //keeping for future use maybe, not needed for now
    /*void Touch_Move_Player()
    {
        var touch = Input.GetTouch(0);
        if (touch.position.x < Screen.width / 2)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }*/

    //Keyboard controls
    void Keyboard_Move_Player()
    {
        float moveX = Input.GetAxis("Horizontal");
        if(moveX > 0)
        {
            direction = 1;
        }
        else if (moveX < 0)
        {
            direction = -1;
        }
    }

    //takes away health point  
    public void Damage(int dmg)
    {
        //checks to see if hit will kill you 
        if (curHealth + dmg > maxHealth)
        {  
            //resets back to starting health
            curHealth = 0;
            print("GAME OVER!");

            Death.YouLost();
            

            //restarts the level. Can change later to send to main menu
            //Application.LoadLevel(Application.loadedLevel);
        }
        //changes adds damage to current health
        else
        {
            curHealth += dmg;
        }
    }


    //knockback feature
    /*
    public IEnumerator Knockback (float KnockDur, float knockBackPwr, Vector3 knockBackDir)
    {
        float timer = 0;

        while (KnockDur > timer)
        {
            timer += Time.deltaTime;

            rb2D.AddForce(new Vector3(knockBackDir.x * -100, knockBackDir.y * knockBackPwr, transform.position.z));

        }

        yield return 0;
    }*/
}

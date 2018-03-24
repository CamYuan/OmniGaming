 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

    private int playerSpeed = 5;
    private int direction = 1;

    public int curHealth = 0;
    public int maxHealth = 2;

    private DeathMenu Death;


    //knockback testing
    //public Rigidbody2D rb2D;


    // Use this for initialization
    void Start () {
        Death = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DeathMenu>();


        //knockback testing
        //rb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Move_Player();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Move_Player()
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
        if (gameObject.GetComponent<Animation>().IsPlaying("Player_RedFlash") == false)
        {
            gameObject.GetComponent<Animation>().Play("Player_RedFlash");
            curHealth += dmg;
            
            //checks to see if hit will kill you
            if(curHealth > maxHealth)
            {
                print("GAME OVER!");
                Death.YouLost();
                //resets health
                curHealth = 2;
            }
        }

        else
        {
            print("Invinsible");
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

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

    private int playerSpeed = 5;
    private int direction = 1;

    public int curHealth = 0;
    public int maxHealth = 2;

    

    // Use this for initialization
    void Start () {
     
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
        //checks to see if hit will kill you 
        if (curHealth + dmg > maxHealth)
        {  
            //resets back to starting health
            curHealth = 0;
            print("GAME OVER!");
            //restarts the level. Can change later to send to main menu
            Application.LoadLevel(Application.loadedLevel);
        }
        //changes adds damage to current health
        else
        {
            curHealth += dmg;
        }
    }
}

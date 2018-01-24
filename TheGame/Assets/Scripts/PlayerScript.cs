 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private int playerSpeed = 5;
    private int direction = 1;
	
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
}

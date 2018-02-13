using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour {

    private PlayerScript player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if collsions happens with the player
        if(collision.CompareTag("Player"))
        {
            print("Collision");
            //calls damage function in PlayerScript
            player.Damage(1);


            //for knockback feature
            //StartCoroutine(player.Knockback(0.05f, 100, player.transform.position));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;
    private PlayerScript Player;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        //matches curHealth to Heartsprites array number for the correct heart pic 
        HeartUI.sprite = HeartSprites[Player.curHealth];
    }
}

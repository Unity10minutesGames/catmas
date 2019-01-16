using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour {

    Color presentColor;
    Vector2 presentPosition;
    Vector2 presentSize;
    int layer;

    //get present list
    //at colorPresents, took presents and give them randomly colors

    //if collider hit, checkColor, if color ok destroy
    //if collider hit, checkColor, if color not ok, show rotten present.
    //renew presents

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
      //destroyPresent   
    }

    private void destroyPresent()
    {
     //shaking present for 2 seconds, fade transperency, animation sparks fly
    }
}

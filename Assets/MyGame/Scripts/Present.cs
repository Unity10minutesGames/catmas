using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour {

    Vector2 presentPosition;
    Vector2 presentSize;
    int sortingOrder;

    private void Start()
    {
        sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder;
    }

    //get present list
    //at colorPresents, took presents and give them randomly colors

    //if collider hit, checkColor, if color ok destroy
    //if collider hit, checkColor, if color not ok, show rotten present.
    //renew presents



    public void destroyPresent()
    {
        //shaking present for 2 seconds, fade transperency, animation sparks fly
        Debug.Log("upppiiii");
        gameObject.SetActive(false);
    }
}

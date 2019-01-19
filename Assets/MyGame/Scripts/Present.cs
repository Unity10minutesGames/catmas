using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour {

    Vector2 presentPosition;
    Vector2 presentSize;
    public int sortingOrder;
    [HideInInspector] public List<Color> order;

    private void Start()
    {
        sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder;
    }

    public bool isRightPresent(int currPos)
    {
        if(order[currPos] == gameObject.GetComponent<SpriteRenderer>().color)
        {
            return true;
        }

        return false;
    }
    
    //if collider hit, checkColor, if color ok destroy
    //if collider hit, checkColor, if color not ok, show rotten present.
    //renew presents



    public void destroyPresent()
    {
        //shaking present for 2 seconds, fade transperency, animation sparks fly
        gameObject.SetActive(false);
    }
}

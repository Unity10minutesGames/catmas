using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentOrder : MonoBehaviour {

    public GameObject present1, present2, present3, present4;
    Color color;

	// Use this for initialization  
	void Start () {
        color = Color.red;
	}

    private Color[] GetColorOrder()
    {
        Color[] colorOrder = new Color[4];
        colorOrder[0] = Color.red;
        colorOrder[0] = Color.blue;
        colorOrder[0] = Color.yellow;
        colorOrder[0] = Color.green;
        return colorOrder;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

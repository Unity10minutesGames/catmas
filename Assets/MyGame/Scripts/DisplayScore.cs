using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour {

    public TextMeshProUGUI text;
    private ScoreSingelton scoreSingelton; 

	// Use this for initialization
	void Start () {
        scoreSingelton = FindObjectOfType<ScoreSingelton>();

        text.SetText ("Super!\n\nYou opened\n\n"+ScoreSingelton.instance.GetDestroyedPrestentScore()+"\n\npresents in the right order!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

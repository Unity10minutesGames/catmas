using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;
using UnityEngine;

public class PresentOrder : MonoBehaviour {

    public List<GameObject> menuCircs;
    public List<GameObject> presentsGame;


    private List<SpriteRenderer> menuCircsRenderer;
    private List<SpriteRenderer> presentsRenderer;

    private List<Color> colorList;

  
    void Start ()
    {
        colorList = new List<Color> {
            Color.red,
            Color.blue,
            Color.green,
            Color.magenta
        };

        SetupMenuCirc();
        SetupPresents();
    }

    private void SetupPresents()
    {
        colorList.Shuffle();
        presentsRenderer = new List<SpriteRenderer>();
        foreach (GameObject item in presentsGame)
        {
            presentsRenderer.Add(item.GetComponent<SpriteRenderer>());
        }

        for (int i = 0; i < presentsRenderer.Count; i++)
        {
            presentsRenderer[i].color = colorList[i];
        }
    }

    private void SetupMenuCirc()
    {
        colorList.Shuffle();
        menuCircsRenderer = new List<SpriteRenderer>();
        foreach (GameObject item in menuCircs)
        {
            menuCircsRenderer.Add(item.GetComponent<SpriteRenderer>());
        }

        for (int i = 0; i < menuCircsRenderer.Count; i++)
        {
            menuCircsRenderer[i].color = colorList[i];
        }
    }
}

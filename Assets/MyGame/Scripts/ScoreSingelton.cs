using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSingelton : MonoBehaviour {

    public static ScoreSingelton instance = null;

    public int destroyedPresents = 10;

    public int DestroyedPresents
    {
        get
        {
            return destroyedPresents;
        }

        set
        {
            destroyedPresents = value;
        }
    }

    public void AddPresent()
    {
        destroyedPresents++;
    }

    public int GetDestroyedPrestentScore()
    {
        return destroyedPresents;
    }

    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("CREANTE INSTANE");
            instance = this;
        }
        else if (instance != this) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
}

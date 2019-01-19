using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

    public Sprite catIdleBehind;
    public AudioClip lick;
    public AudioClip miau;

    private Sprite catIdleAhead;

    private const string STATESCRATCH = "scratch";
    private Player player;
    

    private Animator anim;



    private void Turn()
    {
        if (player.CharacterEyesPlayer)
        {
            GetComponent<SpriteRenderer>().sprite = catIdleBehind;
            player.CharacterEyesPlayer = false;
            GetComponent<Animator>().SetBool("eyesPlayer", false);
            return;
        }

        GetComponent<SpriteRenderer>().sprite = catIdleAhead;
        GetComponent<Animator>().SetBool("eyesPlayer", true);
        player.CharacterEyesPlayer = true;

    }

    // Use this for initialization
    void Start ()
    {
        catIdleAhead = GetComponent<SpriteRenderer>().sprite;
        player = GetComponentInParent<Player>();
        GetComponent<Animator>().SetBool("eyesPlayer", true);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("in Turn");
            Turn();
        }
    }
}

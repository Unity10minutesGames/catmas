using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

    public Sprite catIdleBehind;
    public AudioClip lick;
    public AudioClip miau;
    public AudioClip purr;

    private Sprite catIdleAhead;

    private const string STATESCRATCH = "scratch";
    private Player player;
    
    private Animator anim;

    void Start()
    {
        catIdleAhead = GetComponent<SpriteRenderer>().sprite;
        player = GetComponentInParent<Player>();
        anim = GetComponent<Animator>();
        anim.SetBool("eyesPlayer", true);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Turn();
        }
    }

    private void Turn()
    {
        if (player.CharacterEyesPlayer)
        {
            GetComponent<SpriteRenderer>().sprite = catIdleBehind;
            player.CharacterEyesPlayer = false;
            anim.SetBool("eyesPlayer", false);
            return;
        }

        GetComponent<SpriteRenderer>().sprite = catIdleAhead;
        anim.SetBool("eyesPlayer", true);
        player.CharacterEyesPlayer = true;
    }	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private const string AXISHORIZONTAL = "Horizontal";
    private const string AXISVERTICAL = "Vertical";
    private const string PRESENTBEHIND = "PresentBehind";
    private const string PRESENTAHEAD = "PresentAhead";
    private bool characterEyesPlayer = true;
    private Animator anim;
    private AudioSource[] audioSources;
    private AudioSource playOneShotAudioSource, playMiau, playLick;
    //private ScoreSingelton scoreSingelton;
    private CatController catController;
    private SceneLoader sceneLoader;
    private float xMin, xMax;

    public float moveSpeed = 5.0f;
    public float padding = 0.5f;
    private int currentpos = 0;
    private bool waitForScratchStarted = false;
    private bool StartExcitedCatAnimStarted = false;
    private bool miauStarted = false;

    public bool CharacterEyesPlayer
    {
        get
        {
            return characterEyesPlayer;
        }

        set
        {
            characterEyesPlayer = value;
        }
    }

    private void Start()
    {
        catController = GetComponentInChildren<CatController>();
        anim = GetComponentInChildren<Animator>();
        audioSources = GetComponentsInChildren<AudioSource>();
        //scoreSingelton = FindObjectOfType<ScoreSingelton>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        SetupMoveBounderies();

        playOneShotAudioSource = audioSources[0];
        playMiau = audioSources[1];
        playLick = audioSources[2];

        playOneShotAudioSource.PlayOneShot(catController.purr,0.4f);
    }

    private void SetupMoveBounderies()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x - padding;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis(AXISHORIZONTAL) * Time.deltaTime * moveSpeed;
        var newPosX = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newPosX, transform.position.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Input.HorizontalAxix
        Move();
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == PRESENTBEHIND && !CharacterEyesPlayer)
        {
            HandlePresent(collision);
        }

        if (collision.tag == PRESENTAHEAD && CharacterEyesPlayer)
        {
            HandlePresent(collision);
        }

        if(collision.tag == "Tree" && currentpos > 3)
        {
            sceneLoader.LoadMainGameScene();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("excited", false);
        anim.SetBool("scratch", false);
        waitForScratchStarted = false;

        playMiau.Stop();
        playLick.Stop();

        StartExcitedCatAnimStarted = false;
        
        StopAllCoroutines();
    }

    private void HandlePresent(Collider2D collision)
    {
        StartCoroutine(StartExcitedCatAnim());

        if (collision.gameObject.GetComponent<Present>().isRightPresent(currentpos))
        {
            if (currentpos < 4)
            {
                StartCoroutine(WaitForScratch(collision));
            }  
        }
    }

    private IEnumerator StartExcitedCatAnim()
    {
        if (!StartExcitedCatAnimStarted)
        {
            Debug.Log("Start Clip");
            miauStarted = true;
            if (!playMiau.isPlaying)
            {
                playMiau.Play();
            }
            
            anim.SetBool("eyesPlayer", CharacterEyesPlayer);
            anim.SetBool("excited", true);
            yield return new WaitForSeconds(2);
            StartExcitedCatAnimStarted = true;
        }
    }

    private IEnumerator WaitForScratch(Collider2D collision)
    {
        if (!waitForScratchStarted)
        {
            waitForScratchStarted = true;
            anim.SetBool("eyesPlayer", CharacterEyesPlayer);
            anim.SetBool("scratch", true);
            if (!playLick.isPlaying)
            {
                playLick.Play();
            }
            
            yield return new WaitForSeconds(2);
            Destroy(collision.gameObject);
            ScoreSingelton.instance.AddPresent();
            Debug.Log(ScoreSingelton.instance.DestroyedPresents);
            currentpos++;
        }
    }
}

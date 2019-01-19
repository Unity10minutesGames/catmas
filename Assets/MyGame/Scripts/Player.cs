using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private const string AXISHORIZONTAL = "Horizontal";
    private const string AXISVERTICAL = "Vertical";
    private const string PRESENTBEHIND = "PresentBehind";
    private const string PRESENTAHEAD = "PresentAhead";
    private bool characterEyesPlayer = true;

    private float xMin, xMax;

    public float moveSpeed = 5.0f;
    public float padding = 0.5f;
    int currentpos = 0;
    private bool waitForScratchStarted = false;
    private bool StartExcitedCatAnimStarted = false;

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

	// Use this for initializations
	void Start ()
    {
        SetupMoveBounderies();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Input.HorizontalAxix
        Move();
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("in on Trigger Stay");
        //if(collision.name == "present2Behind")
        if(collision.tag == PRESENTBEHIND && !CharacterEyesPlayer)
        {
            HandlePresent(collision);
        }

        if (collision.tag == PRESENTAHEAD && CharacterEyesPlayer)
        {
            HandlePresent(collision);
        }

        //collision.gameObject.GetComponent<Present>().destroyPresent();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OntriggerExit");
        GetComponentInChildren<Animator>().SetBool("excited", false);
        GetComponentInChildren<Animator>().SetBool("scratch", false);
        waitForScratchStarted = false;
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
            //collision.gameObject.GetComponent<Present>().destroyPresent();
            Debug.Log("in Handle Present");
        }
    }

    private IEnumerator StartExcitedCatAnim()
    {
        if (StartExcitedCatAnimStarted)
        {
            GetComponentInChildren<Animator>().SetBool("eyesWall", CharacterEyesPlayer);
            GetComponentInChildren<Animator>().SetBool("excited", true);
            yield return new WaitForSeconds(2);
            StartExcitedCatAnimStarted = true;
        }
        

    }

    private IEnumerator WaitForScratch(Collider2D collision)
    {
        if (!waitForScratchStarted)
        {
            waitForScratchStarted = true;
            Debug.Log("Startsound");
            GetComponentInChildren<Animator>().SetBool("eyesWall", CharacterEyesPlayer);
            GetComponentInChildren<Animator>().SetBool("scratch", true);
            GetComponentInChildren<AudioSource>().PlayOneShot(GetComponentInChildren<CatController>().lick);
            yield return new WaitForSeconds(2);
            Destroy(collision.gameObject);
            currentpos++;
        }
        
    }
}

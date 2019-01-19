using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private const string AXISHORIZONTAL = "Horizontal";
    private const string AXISVERTICAL = "Vertical";
    private const string STATESCRATCH = "scratch";
    private const string PRESENTBEHIND = "PresentBehind";
    private const string PRESENTAHEAD = "PresentAhead";
    private float xMin, xMax;

    private Animator anim;
    int catscratch = Animator.StringToHash(STATESCRATCH);
    int catidle = Animator.StringToHash("catidle");
    public float moveSpeed = 5.0f;
    public float padding = 0.5f;
    public Sprite catIdleBehind;
    private Sprite catIdleAhead;
    
    private bool characterEyesPlayer = true;
    int currentpos = 0;
    

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

    private void Turn()
    {
        if (characterEyesPlayer)
        {
            GetComponent<SpriteRenderer>().sprite = catIdleBehind;
            characterEyesPlayer = false;
            return;
        }

        GetComponent<SpriteRenderer>().sprite = catIdleAhead;
        characterEyesPlayer = true;

    }

	// Use this for initializations
	void Start ()
    {
        catIdleAhead = GetComponent<SpriteRenderer>().sprite;
        SetupMoveBounderies();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Input.HorizontalAxix
        Move();

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Turn();
        }
        //{
        //    Debug.Log("Arrow down pressed");
        //    anim.SetTrigger(catscratch);
        //}

        //if (Input.GetAxis(AXISVERTICAL))
        //{

        //}

	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if(collision.name == "present2Behind")
        if(collision.tag == PRESENTBEHIND && !characterEyesPlayer)
        {
            HandlePresent(collision);
        }

        if (collision.tag == PRESENTAHEAD && characterEyesPlayer)
        {
            HandlePresent(collision);
        }

        //collision.gameObject.GetComponent<Present>().destroyPresent();
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    private void HandlePresent(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Present>().isRightPresent(currentpos))
        {
            currentpos++;
            currentpos = (int)Mathf.Clamp(currentpos, 0, 3);
            Vector3 tmpPos = gameObject.GetComponent<Transform>().position;
            GetComponent<Animator>().SetBool("excited", true);
            GetComponent<Animator>().SetBool("scratch", true);

            StartCoroutine(WaitForScratch(collision.name));
            //collision.gameObject.GetComponent<Present>().destroyPresent();
            Debug.Log("in Handle Present");
        }
    }

    private IEnumerator WaitForScratch(string colname)
    {
        yield return new WaitForSeconds(3);
        Debug.Log("start anim scratch in penent: " + colname);

    }
}

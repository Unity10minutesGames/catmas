using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private const string AXISHORIZONTAL = "Horizontal";
    private float xMin, xMax;

    public float moveSpeed = 5.0f;
    public float padding = 0.5f;

    

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
        Move();	
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float playerSpeed;
    public float jumpForce;
    private int playerDir;
    private bool grounded;
    public Rigidbody2D rb2d;
    public int flowerCount;
    public GameObject flowerPuff;



	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal") != 0)
        {
            // we are moving
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0));
        }
        if (Input.GetAxis("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            playerDir = 1;
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            playerDir = -1;
        }
        if (Input.GetButton("Jump"))
        {

            jumpForce += 5 * Time.deltaTime;

        }
        if (Input.GetButtonUp("Jump") && grounded == true)
        { 
            grounded = false;
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpForce = 7;

        }


		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if(collision.gameObject.CompareTag("building"))
        {
            print("grounded");
            grounded = true; 
        }


	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.CompareTag("Flower"))
        {
            flowerCount++;
            Instantiate(flowerPuff, transform.position, Quaternion.identity);

        }
	}


}

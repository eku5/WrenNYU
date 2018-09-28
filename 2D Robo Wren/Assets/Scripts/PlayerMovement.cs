﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb;
	private bool grounded;
	public float jumpForce;
	public float walkForce;
	public float dragAmount;
	private bool weJumped;
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			weJumped = true;
		}
	}
	
	void FixedUpdate () {
		if (weJumped && grounded)
		{
			Debug.Log("TRYING TO JUMP");
			//impulse force applies all the force instantly, instead of over time
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			rb.AddForce(Vector2.right * walkForce);
		}
		else
		{
			rb.velocity = new Vector2(Mathf.Min(0, rb.velocity.x), rb.velocity.y);
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			rb.AddForce(Vector2.left * walkForce);
		}
		else
		{
			rb.velocity = new Vector2(Mathf.Max(0, rb.velocity.x), rb.velocity.y);
		}
		
		if (!Input.GetKey(KeyCode.Space))
		{
			rb.velocity = new Vector2(rb.velocity.x, Mathf.Min(0, rb.velocity.y));
		}
		//adds counter force based on squared velocity
		rb.AddForce(-rb.velocity.normalized * rb.velocity.sqrMagnitude * dragAmount);
		grounded = false;
		weJumped = false;
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (Vector2.Dot(coll.contacts[0].normal, Vector2.up) > .4f)
		{
			grounded = true;
		}
	}
}
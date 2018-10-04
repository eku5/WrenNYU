using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{

	public Vector2 jumpHeight;
	
	Rigidbody2D rb;
	private Animator myAnim;
	
	/*
	public bool touchGround;
	public float jumpSpeed = 5f;
	
	[SerializeField]
	private LayerMask whatIsGround;
	*/
	
	// Use this for initialization
	void Start ()
	{
		//touchGround = true;
		rb = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{


		//makes sprite jump

		if ((Input.GetKey(KeyCode.UpArrow)) | (Input.GetKey(KeyCode.Space))) {
			GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
		}


		if (rb.velocity.y > 0.01f)
		{
			myAnim.SetBool("isJumping", true);
		}
		
		if (rb.velocity.y <= 0.01f)
		{
			myAnim.SetBool("isJumping", false);
		}
		
		/*
		if (jumpHeight > 0.01f)
		{
			myAnim.SetBool("isJumping", true);
		}

		if (jumpHeight <= 0.01f)
		{
			myAnim.SetBool("isJumping", false);
		}
		*/

		/*if (touchGround)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				rb.velocity = new Vector2(0f, jumpSpeed);
				touchGround = false;
				myAnim.SetBool("isJumping", true);
			}
			else
			{
				myAnim.SetBool("isJumping", false);
			}
		}
		*/
		
		
	}

	/*
	void OnCollisionEnter2D(Collision2D groundCol)
	{
		if(groundCol.gameObject.CompareTag("Ground"))
		{
			touchGround = true;
		}
	}
	*/
	
}

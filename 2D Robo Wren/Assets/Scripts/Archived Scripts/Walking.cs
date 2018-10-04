using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

    Rigidbody2D rb;
    private Animator myAnim;
    public float walkspeed = 5f;
    //bool for direction sprite is facing;
    public bool facingRight = true;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow)){

            rb.velocity = new Vector2(walkspeed, rb.velocity.y);
            facingRight = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-walkspeed, rb.velocity.y);
      
            facingRight = false;
        }
        
        if (rb.velocity.magnitude > 0.01f)
        {
            myAnim.SetBool("isWalking", true);
        }

        if (rb.velocity.magnitude <= 0.01f)
        {
            myAnim.SetBool("isWalking", false);
        }


        Vector3 theScale = transform.localScale;
        if (facingRight)
            theScale.x = 1;
        else
            theScale.x = -1;
        transform.localScale = theScale;

	}

    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

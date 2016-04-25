using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpForce;
    private Vector2 movement = Vector2.zero;
    private bool isGrounded = false;
    private float ySpeed = 0;
    private float gravity = 0.005f;

	void FixedUpdate () {
        movement = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, ySpeed);
        transform.Translate(movement);

        if(!isGrounded)
        {
            ySpeed -= gravity;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetButton("Jump") && isGrounded)
        {
            //rb.AddForce(Vector2.up * jumpForce);
            ySpeed = jumpForce;
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("isGrounded");
        if(coll.gameObject.tag == Tags.ground)
        {
            ySpeed = 0;
            Debug.Log("isGrounded");
            isGrounded = true;
        }
        else if (coll.gameObject.tag == Tags.ceiling)
        {
            ySpeed = -0;
        }
    }
}

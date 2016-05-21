using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip landSound;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpForce;
    private Vector2 movement = Vector2.zero;
    private bool isGrounded = false;
    private float ySpeed = 0;
    private float gravity = 0.005f;
    private Vector3 scale;
    private Vector3 leftScale;

    void Start()
    {
        scale = leftScale = transform.localScale;
        leftScale.x *= -1;
    }
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, ySpeed);
    }
    void FixedUpdate () {
        if(movement.x < 0)
        {
            transform.localScale = leftScale;
        }
        else if (movement.x > 0)
        {
            transform.localScale = scale;
        }
        transform.Translate(movement);
        if(!isGrounded)
        {
            ySpeed -= gravity;
        }
        if (Input.GetButton("Jump") && isGrounded)
        {
            GetComponent<AudioSource>().clip = jumpSound;
            GetComponent<AudioSource>().Play();
            ySpeed = jumpForce;
            isGrounded = false;
        }
        if(!Input.GetButton("Jump") && ySpeed > 0 && !isGrounded)
        {
            ySpeed = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == Tags.ground)
        {
            ySpeed = 0;
            isGrounded = true;
            GetComponent<AudioSource>().clip = landSound;
            GetComponent<AudioSource>().Play();
        }
        else if (coll.gameObject.tag == Tags.ceiling)
        {
            ySpeed = 0;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Tags.ground)
        {
            isGrounded = false;
        }
    }
    public float YSpeed
    {
        set { ySpeed = value; }
    }

}

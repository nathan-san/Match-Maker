using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpForce;
    private Vector2 movement = Vector2.zero;

	void FixedUpdate () {
        movement = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, 0);
        transform.Translate(movement);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}

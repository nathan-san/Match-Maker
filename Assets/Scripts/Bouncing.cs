using UnityEngine;
using System.Collections;

public class Bouncing : MonoBehaviour {

    [SerializeField]
    private int sizeId = 4;

    [SerializeField]
    private float xSpeed=0.05f;

    private float ySpeed=0;
    private float gravityMultiplier = -0.004f;
    private float jumpForce = 0.2f;

    void Start()
    {
        CalculateBallDataValues();
    }
    void CalculateBallDataValues()
    {
        transform.localScale = new Vector3(BallData.sizes[sizeId], BallData.sizes[sizeId], BallData.sizes[sizeId]);
        gravityMultiplier = BallData.gravities[sizeId];
    }
	void Update ()
    {
        ySpeed += gravityMultiplier;
	}
    void FixedUpdate()
    {
        transform.Translate(xSpeed,ySpeed,0f);
    }
    void OnCollisionEnter2D(Collision2D colliderObject)
    {
        if (colliderObject.gameObject.tag == Tags.ground)
        {
            ySpeed = jumpForce;
        }
        else if(colliderObject.gameObject.tag == Tags.wall)
        {
            xSpeed = -xSpeed;
        }
        else if(colliderObject.gameObject.tag == Tags.ceiling)
        {
            ySpeed = -ySpeed;
        }
    }
    void OnMouseDown()
    {
        Damage();
    }
    public float XSpeed
    {
        set { xSpeed = value; }
    }
    public float YSpeed
    {
        set { ySpeed = value; }
    }
    void Damage()
    {
        if(sizeId == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sizeId--;
            GameObject extraBall = Instantiate(this.gameObject, transform.position, Quaternion.identity)as GameObject;
            extraBall.GetComponent<Bouncing>().XSpeed = -xSpeed;

            extraBall.GetComponent<Bouncing>().YSpeed = jumpForce /(sizeId+1);
            ySpeed = jumpForce /(sizeId+1);

            CalculateBallDataValues();
        }
    }
}

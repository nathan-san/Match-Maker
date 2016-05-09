using UnityEngine;
using System.Collections;
public class Bouncing : MonoBehaviour {

    [SerializeField]
    private int sizeId = 4;

    [SerializeField]
    private float xSpeed = 0.05f;

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
    void OnTriggerEnter2D(Collider2D colliderObject)
    {
        
        if((transform.position.x <colliderObject.transform.position.x && xSpeed > 0) || (transform.position.x > colliderObject.transform.position.x && xSpeed < 0))
        {
            Damage(false);
        }
        else
        {
            Damage(true);
        }
        
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
        else if (colliderObject.gameObject.tag == Tags.player)
        {
            Destroy(colliderObject.gameObject);
            GameObject.Find("SceneManager").GetComponent<SceneLoader>().RestartScene();
            //Time.timeScale = 0f;
            
        }
    }
    public float XSpeed
    {
        set { xSpeed = value; }
    }
    public float YSpeed
    {
        set { ySpeed = value; }
    }
    void Damage(bool right)
    {
        if(sizeId == 0)
        {
            Destroy(this.gameObject);
            GameObject.Find("BallCounter").GetComponent<ObjectsWithTagCounter>().CountObjectsWithTag();
        }
        else
        {
            sizeId--;
            GameObject extraBall = Instantiate(this.gameObject, transform.position, Quaternion.identity)as GameObject;

            if(!right)
            {
                extraBall.GetComponent<Bouncing>().XSpeed = -xSpeed/0.8f;
                GetComponent<Bouncing>().XSpeed = -xSpeed;
            }
            else
            {
                extraBall.GetComponent<Bouncing>().XSpeed = xSpeed / 0.8f;
                GetComponent<Bouncing>().XSpeed = xSpeed;
            }
            GetComponent<Bouncing>().YSpeed = jumpForce /(sizeId/2+1)+0.05f;
            ySpeed = jumpForce /(sizeId/2+1);

            CalculateBallDataValues();
        }
    }
}

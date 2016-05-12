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
    private bool canInteract = true;

    public delegate void DamageAction(float value);
    public static event DamageAction OnDamage;

    public delegate void CountAction();
    public static event CountAction OnDisappearing;

    public delegate void HitPlayer(float timeScale, float duration, string text);
    public static event HitPlayer OnHittingPlayer;
    void Start()
    {
        CalculateBallDataValues();
    }
    void CalculateBallDataValues()
    {
        ySpeed = jumpForce;
        transform.localScale = new Vector3(BallData.sizes[sizeId], BallData.sizes[sizeId], BallData.sizes[sizeId]);
        gravityMultiplier = BallData.gravities[sizeId];
        StartCoroutine(CantBeHarmed());
    }

    IEnumerator CantBeHarmed()
    {
        canInteract = false;
        yield return new WaitForSeconds(0.1f);
        canInteract = true;
    }
    void FixedUpdate()
    {
        ySpeed += gravityMultiplier;
        transform.Translate(xSpeed,ySpeed,0f);
    }
    void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if(canInteract)
        {
            if ((transform.position.x < colliderObject.transform.position.x && xSpeed > 0) || (transform.position.x > colliderObject.transform.position.x && xSpeed < 0))
            {
                Damage(false);
            }
            else
            {
                Damage(true);
            }
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
        else if (colliderObject.gameObject.tag == Tags.player && canInteract)
        {
            Destroy(colliderObject.gameObject);
            if(OnHittingPlayer != null)
            {
                OnHittingPlayer(0.5f, 3f, "You got hit!");
            }
        }
    }
    //function called when a ball is damaged by the player.
    void Damage(bool right)
    {
        if(OnDamage != null)
        {
            OnDamage(12 * (sizeId+1));
        }
        if (sizeId == 0)
        {
            Destroy(this.gameObject);
            if(OnDisappearing != null)
            {
                OnDisappearing();
            }
        }
        else
        {
            sizeId--;
            GameObject extraBall = Instantiate(this.gameObject, transform.position, Quaternion.identity) as GameObject;

            extraBall.GetComponent<Bouncing>().XSpeed = xSpeed;
            GetComponent<Bouncing>().XSpeed = -xSpeed;

            CalculateBallDataValues();
        }
    }

    //getters and setters.
    public float XSpeed
    {
        set { xSpeed = value; }
    }
    public float YSpeed
    {
        set { ySpeed = value; }
    }


}

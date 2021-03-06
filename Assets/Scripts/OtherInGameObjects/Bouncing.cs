﻿using UnityEngine;
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
        transform.Rotate(0f, 0f, xSpeed *100f);
        transform.Translate(xSpeed,ySpeed,0f, Space.World);
    }
    void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if(canInteract)
        {
            Damage();
        }
    }
    void OnCollisionEnter2D(Collision2D colliderObject)
    {
        if (colliderObject.gameObject.tag == Tags.ground)
        {
            ySpeed = jumpForce;
            GetComponent<AudioSource>().pitch = 2 - sizeId / 5;
            GetComponent<AudioSource>().Play();
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
            EventManager.HittingPlayer(0.5f, 3f, "You got hit!");
        }        
    }

    //function called when a ball is damaged by the player.
    void Damage()
    {
        EventManager.Damage(12 * (sizeId+1));
        if (sizeId == 0)
        {

            Destroy(this.gameObject);

            EventManager.Count();
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

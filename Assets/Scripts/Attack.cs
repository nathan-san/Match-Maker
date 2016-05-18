using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    [SerializeField]
    private AudioClip attacksound;
    [SerializeField]
    private GameObject hitBox;
    private bool isAttacking = false;
    [SerializeField]
    private float restTime = 0.1f;
	void Update () {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            StartCoroutine(Attacking());
        }
    }
    IEnumerator Attacking()
    {
        //plays the attack sound
        GetComponent<AudioSource>().clip = attacksound;
        GetComponent<AudioSource>().Play();

        isAttacking = true;
        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitBox.SetActive(false);
        yield return new WaitForSeconds(restTime);
        isAttacking = false;
    }
}

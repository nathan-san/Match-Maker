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

    [SerializeField]
    private bool animating = false;
    private Animator animator;

    void Start()
    {
        if (animating) animator = GetComponent<Animator>();
    }
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
        if (animating)
            animator.SetBool("attacking", true);
        yield return new WaitForSeconds(0.01f);
        if (animating)
            animator.SetBool("attacking", false);

        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitBox.SetActive(false);
        isAttacking = false;



    }
}

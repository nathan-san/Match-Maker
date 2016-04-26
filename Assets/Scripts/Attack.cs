using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

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
        isAttacking = true;
        hitBox.SetActive(true);
        yield return new WaitForSeconds(restTime);
        isAttacking = false;
        hitBox.SetActive(false);
    }
}

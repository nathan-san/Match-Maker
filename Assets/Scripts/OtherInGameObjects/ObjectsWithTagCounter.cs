using UnityEngine;
using System.Collections;
public class ObjectsWithTagCounter : MonoBehaviour {
    [SerializeField]
    private string tag;
    private GameObject[] objects;

    void Start()
    {
        EventManager.OnDisappearing += CountObjectsWithTag;
    }
    public void CountObjectsWithTag()
    {
        
        StartCoroutine(Counting());
    }
    IEnumerator Counting()
    {
        yield return new WaitForSeconds(0.1f);
        objects = GameObject.FindGameObjectsWithTag(tag);
        if (objects.Length ==0)
        {
            EventManager.Win(1, "Victory!");
        }
    }
}

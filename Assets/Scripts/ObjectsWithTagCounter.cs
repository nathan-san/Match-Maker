using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ObjectsWithTagCounter : MonoBehaviour {
    [SerializeField]
    private string tag;
    private GameObject[] objects;
    [SerializeField]
    private Text winText;

    public void CountObjectsWithTag()
    {
        objects = GameObject.FindGameObjectsWithTag(tag);
        if (objects.Length == 1)
        {
            winText.text = "You won!";
        }
    }
}

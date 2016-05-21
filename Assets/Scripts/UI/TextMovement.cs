using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextMovement : MonoBehaviour {
    private RectTransform textPosition;
    [SerializeField]
    private Vector2 direction;
    private Vector2 temp;
	// Use this for initialization
	void Start () {
        textPosition = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        temp = textPosition.position;
        temp += direction;
        textPosition.position = temp;
    }
}

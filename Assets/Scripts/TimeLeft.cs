using UnityEngine;
using System.Collections;
public class TimeLeft : MonoBehaviour {
	[SerializeField]
    private float timeLimit;
    private float timeDevision;
    private Vector3 scale;
    [SerializeField]
    private WinLoseStateManager manager;
    void Start() {
		scale = transform.localScale;
		timeDevision = timeLimit / scale.x;
	}

	void FixedUpdate () {
		if (timeLimit > 0f) {
			timeLimit -= Time.deltaTime;
			scale.x = timeLimit / timeDevision;
			transform.localScale = scale;
		}
        else
        {
            manager.Lost(0.001f, 2, "time's up!");
        }
	}
}

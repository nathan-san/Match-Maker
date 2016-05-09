using UnityEngine;
using System.Collections;

public class TimeLeft : MonoBehaviour {
	[SerializeField]
	private float timeLimit;
	private Vector3 scale;
	private float timeDevision;

	void Start() {
		scale = transform.localScale;
		timeDevision = timeLimit / scale.x;
	}

	void Update () {
		if (timeLimit > 0f) {
			timeLimit -= Time.deltaTime;
			scale.x = timeLimit / timeDevision;
			transform.localScale = scale;
		}
	}
}

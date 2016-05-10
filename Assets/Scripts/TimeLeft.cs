using UnityEngine;
using System.Collections;
public class TimeLeft : MonoBehaviour {
	[SerializeField]
    private float timeLimit;
    private float timeDevision;
    private float timeScaling = 1;
    private Vector3 scale;
    [SerializeField]
    private WinLoseStateManager manager;
    void Start() {
		scale = transform.localScale;
		timeDevision = timeLimit / scale.x;
	}

	void FixedUpdate () {
		if (timeLimit > 0f) {
			timeLimit -= Time.deltaTime * timeScaling;
			scale.x = timeLimit / timeDevision;
			transform.localScale = scale;
		}
        else if (timeScaling ==1)
        {
            manager.Lost(0.001f, 2, "time's up!");
        }
	}
    public float TimeScaling
    {
        get { return timeScaling; }
        set { timeScaling = value; }
    }
    public float TimeLimit
    {
        get { return timeLimit; }
        set { timeLimit = value; }
    }
}

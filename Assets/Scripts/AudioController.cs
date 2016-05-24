using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {
	[SerializeField]
	private bool sound = true;

	void Update () {
		sound = GetComponent<Toggle> ().isOn;
	}

	public void AudioControl() {
		if (sound == false) {
			AudioListener.volume = 1;
		} else if (sound == true) {
			AudioListener.volume = 0;
		}
	}
}

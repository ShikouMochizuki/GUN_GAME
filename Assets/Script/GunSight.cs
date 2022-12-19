using UnityEngine;
using UnityEngine.UI;

public class GunSight : MonoBehaviour {

	private Text comText;
	private bool isDisplay;

	void Start() {
		comText = gameObject.GetComponent<UnityEngine.UI.Text>();
		isDisplay = false;
		comText.enabled = false;
	}

	void Update() {
		if (GameState.State == GameState.PLAY && isDisplay == false) {
			isDisplay = true;
			comText.enabled = true;
		}
	}
}

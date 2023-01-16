using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	private Text comText;

	void Start() {
		comText = gameObject.GetComponent<Text>();
		comText.text = "SCORE: 0";
		comText.enabled = false;
	}

	void Update() {
		if (GameState.State == GameState.COUNT_DOWN)
			comText.enabled = true;
		else if (GameState.State == GameState.PLAY)
			comText.text = "SCORE: " + Score.GetPoint().ToString();
		else if (GameState.State == GameState.END)
			comText.enabled = false;
	}
}

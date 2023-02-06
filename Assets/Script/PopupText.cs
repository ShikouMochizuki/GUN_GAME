using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupText : MonoBehaviour {

	private Text comText;
	private int count;

	void Start() {
		comText = gameObject.GetComponent<Text>();
		comText.enabled = false;
		Score.SetText(this);
	}

	void Update() {
		if (count > 0)
			--count;
		if (count <= 0)
			comText.enabled = false;

		if (count % 10 < 5)
			comText.color = new Color(1f, 0, 0);
		else
			comText.color = new Color(1f, 1f, 0);
	}

	public void DisplayPoint(int point, int rate) {
		comText.text = "+ " + point + "�~" + rate;
		comText.enabled = true;
		count = 60;
	}
}

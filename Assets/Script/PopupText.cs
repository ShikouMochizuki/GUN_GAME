using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupText : MonoBehaviour {

	private Text comText;
	private int count;
	private bool red = true;

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
			comText.color = (red ? new Color(1f, 0, 0) : new Color(1f, 0.5f, 0));
		else
			comText.color = new Color(0.8f, 0.8f, 0);
	}

	public void DisplayPoint(int point, int rate) {
		comText.text = "+ " + point + "~" + rate;
		comText.enabled = true;
		count = 60;
		red = (point == 10 ? false : true);
	}
}

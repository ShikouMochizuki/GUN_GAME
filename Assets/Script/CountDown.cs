using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	private int count = 0;
	private int NumberDisplayed = 3;
	private Text comText;

	void Start() {
		comText = gameObject.GetComponent<UnityEngine.UI.Text>();
	}

	void Update() {
		++count;
		if (count % Application.targetFrameRate == 0)
			--NumberDisplayed;

		if (NumberDisplayed > 0)
			comText.text = NumberDisplayed.ToString();
		else
			comText.text = "START";

		if (NumberDisplayed < 0) {
			Destroy(comText);
			GameState.State = GameState.PLAY;
		}
	}
}

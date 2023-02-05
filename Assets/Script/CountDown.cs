using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	private int count = 0;
	private int NumberDisplayed = 3;
	private bool end = false;
	private Text comText;

	void Start() {
		comText = gameObject.GetComponent<UnityEngine.UI.Text>();
	}

	void Update() {
		++count;
		if (Input.GetKeyDown(KeyCode.Q))
			NumberDisplayed = -1;
		if (count % Application.targetFrameRate == 0)
			--NumberDisplayed;

		if (NumberDisplayed > 0)
			comText.text = NumberDisplayed.ToString();
		else
			comText.text = "START";

		if (NumberDisplayed < 0 && !end) {
			Destroy(comText);
			GameState.State = GameState.PLAY;
			end = true;
		}
	}
}

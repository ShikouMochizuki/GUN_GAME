using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour{

	public int TimeLimitS = 90;

	private bool isRun = false;
	private float StartTime;
	private float time;

	private int timeS = 0;
	private int timeM = 0;
	private int timeMS = 0;

	private Text comText;

	void Start() {
		comText = gameObject.GetComponent<UnityEngine.UI.Text>();
		comText.text = "残り時間";
		comText.enabled = false;
	}

	void Update() {
		if (GameState.State == GameState.COUNT_DOWN)
			comText.enabled = true;
		else if (GameState.State == GameState.PLAY) {
			if (!isRun) {
				isRun = true;
				StartTime = Time.time;
			}
			else {
				time = TimeLimitS - (Time.time - StartTime);
				timeS = (int)time;
				timeM = timeS / 60;
				timeS -= timeM * 60;
				timeMS = (int)((time % 1f) * 100);
				comText.text =
					(timeM < 10  ? "0" + timeM.ToString()  : timeM.ToString()) + ":" +
					(timeS < 10  ? "0" + timeS.ToString()  : timeS.ToString()) + ":" +
					(timeMS < 10 ? "0" + timeMS.ToString() : timeMS.ToString());

				//comText.text = time.ToString();
				if (time < 0) {
					GameState.State = GameState.END;
					Debug.Log("終了しましたよ");
				}
			}
		}
		else if (GameState.State == GameState.END) {
			isRun = false;
			//comText.enabled = false;
			comText.text = "ゲーム終了 エスケープキーでタイトルに戻ります";
			if (Input.GetKey(KeyCode.Escape)) {
				GameState.State = GameState.TITLE;
				SceneManager.LoadScene("a");
			}
		}
		// デバッグ用
		if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.P))
			GameState.State = GameState.COUNT_DOWN;
	}
}

using UnityEngine;

public class Ready : MonoBehaviour {

	public int FrameRate = 60;
	
	void Start() {
		Application.targetFrameRate = 60;
		//QualitySettings.vSyncCount = 0;
	}
}

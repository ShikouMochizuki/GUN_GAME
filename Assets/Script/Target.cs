using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public GameObject explosionPrefab;
	public int point = 10;
	public int WaitingTime = 180;		// フレーム単位

	private static int TargetNum = 0;
	private TargetSpawnPoint MyPoint;
	private int count = 0;
	private float Size = 0.0f;

	void Awake() {
		++TargetNum;
		transform.localScale = new Vector3(0f, 0f, 0f);
		Debug.Log(TargetNum + " Created");
	}

	// 3秒待った後、スケール2まで徐々に大きくなっていく
	void Update() {
		if (count < WaitingTime)
			++count;
		else if (Size < 2.0f) {
			transform.localScale = new Vector3(Size, Size, Size);
			Size += 0.1f;
		}
	}

	public void SetSpawnPoint(TargetSpawnPoint Point) {
		MyPoint = Point;
	}

	void OnDestroy() {
		--TargetNum;
		Debug.Log(TargetNum + " Deleted");
	}

	public static int GetTargetNum() {
		return TargetNum;
	}

	private void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Bullet") {
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			MyPoint.NotifyDeleteTarget();
			Score.AddPoint(point);
			Debug.Log(Score.GetPoint());
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

	private List<TargetSpawnPoint> ArrSpawnPoint;
	public int MaxTargetNum = 5;

	void Start() {
		// 子要素のスポーン地点を取得
		ArrSpawnPoint = new List<TargetSpawnPoint>();
		for (int i = 0; i < transform.childCount; ++i)
			ArrSpawnPoint.Add(transform.GetChild(i).gameObject.GetComponent<TargetSpawnPoint>());
		// Updateで無限ループしないようにする
		MaxTargetNum = (MaxTargetNum < ArrSpawnPoint.Count ? MaxTargetNum : ArrSpawnPoint.Count);
	}

	void Update() {
		int count = 0;
		// ターゲット配置アルゴリズムがガバガバ仕様なので暇があれば直す
		// このアルゴリズムでは、発生ポイントがターゲット数の倍以上ないと厳しいかも
		while (Target.GetTargetNum() < MaxTargetNum) {
			++count;
			var SpawnPoint = ArrSpawnPoint[Random.Range(0, ArrSpawnPoint.Count)];
			if (SpawnPoint.CheckUsed())
				continue;
			else
				SpawnPoint.SetTarget();

			// 無限ループ対策
			if (count > 100)
				break;
		}
	}
}

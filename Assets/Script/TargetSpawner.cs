using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

	private List<GameObject> ArrSpawnPoint;

	void Start() {
		// 子要素のスポーン地点を取得
		ArrSpawnPoint = new List<GameObject>();
		for (int i = 0; i < transform.childCount; ++i)
			ArrSpawnPoint.Add(transform.GetChild(i).gameObject);
	}

	void Update() {
		
	}
}

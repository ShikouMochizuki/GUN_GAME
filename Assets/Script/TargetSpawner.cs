using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

	private List<GameObject> ArrSpawnPoint;

	void Start() {
		// �q�v�f�̃X�|�[���n�_���擾
		ArrSpawnPoint = new List<GameObject>();
		for (int i = 0; i < transform.childCount; ++i)
			ArrSpawnPoint.Add(transform.GetChild(i).gameObject);
	}

	void Update() {
		
	}
}

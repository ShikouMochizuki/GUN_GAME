using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnPoint : MonoBehaviour {

	private bool isUse = false;

	void Start() {
		GetComponent<Renderer>().enabled = false;
		//enabled = true;
	}

	public bool SetTarget() {
		if (isUse)
			return false;
		isUse = true;
		return true;
	}

	public bool DeleteTarget() {
		return true;
	}
}

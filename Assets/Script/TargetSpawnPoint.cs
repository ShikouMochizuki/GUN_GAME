using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnPoint : MonoBehaviour {

	private bool isUse = false;
	private int count = 0;
	public GameObject TargetPrefab;

	void Start() {
		GetComponent<Renderer>().enabled = false;
	}
	
	public bool SetTarget() {
		if (isUse)
			return false;
		var target = Instantiate(TargetPrefab, transform.position, transform.rotation);
		target.GetComponent<Target>().SetSpawnPoint(this);
		isUse = true;
		return true;
	}

	public void NotifyDeleteTarget() {
		isUse = false;
	}

	public bool CheckUsed() {
		return isUse;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_ht : MonoBehaviour {

	public GameObject explosionPrefab;

	private void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Bullet") {
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}

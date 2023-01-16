using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_ht : MonoBehaviour {

	public GameObject explosionPrefab;
	public int point = 10;
	private void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Bullet") {
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Score.AddPoint(point);
			Debug.Log(Score.GetPoint());
			Destroy(gameObject);
		}
	}
}

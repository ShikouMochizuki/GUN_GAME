using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float MaxSpeedHorizontal = 4f;	// 水平方向最高速度
	public float MaxAscentSpeed = 0.15f;	// 最高上昇速度
	public float MaxFallSpeed = 0.2f;		// 最高落下速度

	public float ForceHorizontalMove = 30;
	public float ForceAscent = 5;
	
	void Start() {
		
	}

	void Update() {
		Move();
	}

	private void OnCollisionStay(Collision collision) {
		if (Input.GetKey(KeyCode.Space) && collision.gameObject.name == "Terrain")
			Jump();
	}

	private void Move() {
		var rb = gameObject.GetComponent<Rigidbody>();

		// 入力を元に力を加える
		var ForceH = new Vector3(0f, 0f, 0f);
		var ForceV = new Vector3(0f, 0f, 0f);
		if (Input.GetKey(KeyCode.E)) ForceH.z = ForceHorizontalMove;
		if (Input.GetKey(KeyCode.F)) ForceH.x = ForceHorizontalMove;
		if (Input.GetKey(KeyCode.D)) ForceH.z = -1f * ForceHorizontalMove;
		if (Input.GetKey(KeyCode.S)) ForceH.x = -1f * ForceHorizontalMove;

		// 速度制限
		float vSpeedHorizontal = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z);
		if (vSpeedHorizontal > MaxSpeedHorizontal) {
			var unitVec = new Vector3(
				rb.velocity.x / vSpeedHorizontal,
				0f,
				rb.velocity.z / vSpeedHorizontal
			);
			rb.velocity = new Vector3(
				unitVec.x * MaxSpeedHorizontal,
				rb.velocity.y,
				unitVec.z * MaxSpeedHorizontal
			);
		}

		rb.AddForce(ForceH);
	}

	private void Jump() {
		gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, ForceAscent, 0f), ForceMode.Impulse);
	}
}

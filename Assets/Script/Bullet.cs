using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float LifeSpan = 3;
	public int HitPoint = 2;
	public bool isReflect = false;
	public int count = 0;

	void Awake() {
		Destroy(gameObject, LifeSpan);
	}

	void Update() {
		if (count < 3) ++count;
		if (HitPoint < 2 && count > 1)
			isReflect = true;
	}

	void OnCollisionEnter(Collision collision) {
		//Destroy(collision.gameObject);
		//if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Wall")


		// ���C���[�𕪂����̂ŁA�����ȕǂ�v���C���[�Ƃ͂��������Փ˂��Ȃ�
		// �q�b�g����͏������G����
		if (count >= 3) {
			--HitPoint;
			count = 0;
		}
		if (HitPoint <= 0)
			Destroy(gameObject);
	}
}

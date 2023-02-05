using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

	private List<TargetSpawnPoint> ArrSpawnPoint;
	public int MaxTargetNum = 5;

	void Start() {
		// �q�v�f�̃X�|�[���n�_���擾
		ArrSpawnPoint = new List<TargetSpawnPoint>();
		for (int i = 0; i < transform.childCount; ++i)
			ArrSpawnPoint.Add(transform.GetChild(i).gameObject.GetComponent<TargetSpawnPoint>());
		// Update�Ŗ������[�v���Ȃ��悤�ɂ���
		MaxTargetNum = (MaxTargetNum < ArrSpawnPoint.Count ? MaxTargetNum : ArrSpawnPoint.Count);
	}

	void Update() {
		int count = 0;
		// �^�[�Q�b�g�z�u�A���S���Y�����K�o�K�o�d�l�Ȃ̂ŉɂ�����Β���
		// ���̃A���S���Y���ł́A�����|�C���g���^�[�Q�b�g���̔{�ȏ�Ȃ��ƌ���������
		while (Target.GetTargetNum() < MaxTargetNum) {
			++count;
			var SpawnPoint = ArrSpawnPoint[Random.Range(0, ArrSpawnPoint.Count)];
			if (SpawnPoint.CheckUsed())
				continue;
			else
				SpawnPoint.SetTarget();

			// �������[�v�΍�
			if (count > 100)
				break;
		}
	}
}

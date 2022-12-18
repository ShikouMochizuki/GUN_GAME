using UnityEngine;

// Ground�^�O�������I�u�W�F�N�g��n�`�Ƃ��ĔF������B
// �ڐG��W�����v�̔���Ŏg�p
public class Player2 : MonoBehaviour {

	public float MaxSpeedWalk  = 0.09f;	// ���������ō����x�i�E�H�[�N�j
	public float MaxSpeedRun   = 0.14f;	// �_�������ō����x�i�_�b�V���j
	public float AccHorizontal = 0.02f;    // �������������x

	public float MaxSpeedVertical = 0.13f;	// ���������ō����x
	public float AscentSpeed	  = 0.13f;	// �W�����v���̏㏸���x
	public int   JumpPower		  = 30;		// �W�����v�́i���l�������قǍ������ׂ�j
	public float AccGravity		  = 0.005f;	// �d�͉����x

	public float TurnSpeedY = 3.5f;		// �J������Y���ɑ΂����]���x
	public float TurnSpeedX = 3.5f;		// �J������X���ɑ΂����]���x

	public Camera PlayerCamera;

	private CharacterController cc;
	private Vector3 move;
	private int CountJump;
	private bool isJump = false;

	void Start() {
		cc = gameObject.GetComponent<CharacterController>();
	}

	void Update() {
		if (GameState.State == GameState.PLAY) {
			ChangeAngle();
			OperateVelocityHorizontal();
			OperateVelocityVertical();
			cc.Move(move);
		}
	}

	//private void OnCollisionStay(Collision collision) {
	//	if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "Ground")
	//		Jump();
	//}

	private void OperateVelocityHorizontal() {
		// ���͂����ɐ��������։���
		//var ForceH = new Vector3(0f, 0f, 0f);
		//if (Input.GetKey(KeyCode.W)) move.z += AccHorizontal;
		//if (Input.GetKey(KeyCode.D)) move.x += AccHorizontal;
		//if (Input.GetKey(KeyCode.S)) move.z += -1f * AccHorizontal;
		//if (Input.GetKey(KeyCode.A)) move.x += -1f * AccHorizontal;

		// ���C�ɂ�錸��
		//if (cc.isGrounded)

		// �ō����x������
		float SpeedLimit;
		if (Input.GetMouseButton(1))
			SpeedLimit = MaxSpeedRun;
		else
			SpeedLimit = MaxSpeedWalk;

		// ���͂��琅�������̑��x������
		if (Input.GetKey(KeyCode.W)) move.z = SpeedLimit;
		else if (Input.GetKey(KeyCode.S)) move.z = -1f * SpeedLimit;
		else move.z = 0;

		if (Input.GetKey(KeyCode.D)) move.x = SpeedLimit;
		else if (Input.GetKey(KeyCode.A)) move.x = -1f * SpeedLimit;
		else move.x = 0;

		// ���������̑��x����
		//float vSpeedHorizontal = Mathf.Sqrt(move.x * move.x + move.z * move.z);
		//if (vSpeedHorizontal > SpeedLimit) {
		//	var unitVec = new Vector3(
		//		move.x / vSpeedHorizontal,
		//		0f,
		//		move.z / vSpeedHorizontal
		//	);
		//	move = new Vector3(
		//		unitVec.x * SpeedLimit,
		//		move.y,
		//		unitVec.z * SpeedLimit
		//	);
		//}
	}

	private void OperateVelocityVertical() {
		// �W�����v
		if (Input.GetKey(KeyCode.Space) && cc.isGrounded) {
			isJump = true;
			CountJump = 0;
		}
		if (isJump) {
			move.y = AscentSpeed;
			++CountJump;
			if (!Input.GetKey(KeyCode.Space) || CountJump >= JumpPower)
				isJump = false;
		}

		// �d��
		move.y -= AccGravity;

		// ���������̑��x����
		if (move.y > MaxSpeedVertical)
			move.y = MaxSpeedVertical;
		if (move.y < -1 * MaxSpeedVertical)
			move.y = -1 * MaxSpeedVertical;
	}

	private void ChangeAngle() {
		float MouseMoveX = Input.GetAxis("Mouse X");
		float MouseMoveY = Input.GetAxis("Mouse Y");
		float turnSpeedY = MouseMoveX * TurnSpeedY;
		float turnSpeedX = MouseMoveY * TurnSpeedY * -1;

		var angle = PlayerCamera.transform.eulerAngles.x;
		if (   angle > 70       && angle < 180 && turnSpeedX > 0	// ����]���~�߂�
			|| angle < 360 - 70 && angle > 180 && turnSpeedX < 0)	// ���]���~�߂�
			turnSpeedX = 0f;

		//transform.Rotate(new Vector3(0f, turnSpeedY, 0f));
		cc.transform.Rotate(new Vector3(0f, turnSpeedY, 0f));
		PlayerCamera.transform.Rotate(new Vector3(turnSpeedX, 0f, 0f));
	}
}

// transform.eulerAngles �́A0�`360�̒l��Ԃ��B���ɑ΂��āA�E�˂������Ō�������B
// �E�˂��̋t�ő����Ă����̂ł���B

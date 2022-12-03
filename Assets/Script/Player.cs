using UnityEngine;

// Ground�^�O�������I�u�W�F�N�g��n�`�Ƃ��ĔF������B
// �ڐG��W�����v�̔���Ŏg�p
public class Player : MonoBehaviour {

	public float MaxSpeedHorizontal = 4f;   // ���������ō����x
	public float MaxAscentSpeed = 0.15f;    // �ō��㏸���x
	public float MaxFallSpeed = 0.2f;       // �ō��������x

	public float ForceHorizontalMove = 30;
	public float ForceAscent = 5;

	public float TurnSpeedY = 4f;
	public float TurnSpeedX = 4f;

	public Camera PlayerCamera;

	private Rigidbody rb;

	void Start() {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void Update() {
		ChangeAngle();
		Move();
	}

	private void OnCollisionStay(Collision collision) {
		if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "Ground")
			Jump();
	}

	private void Move() {
		// ���͂����ɗ͂�������
		var ForceH = new Vector3(0f, 0f, 0f);
		if (Input.GetKey(KeyCode.E)) ForceH.z = ForceHorizontalMove;
		if (Input.GetKey(KeyCode.F)) ForceH.x = ForceHorizontalMove;
		if (Input.GetKey(KeyCode.D)) ForceH.z = -1f * ForceHorizontalMove;
		if (Input.GetKey(KeyCode.S)) ForceH.x = -1f * ForceHorizontalMove;

		// ���x����
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

		// �͂�������
		rb.AddForce(transform.rotation * ForceH);
		//Debug.Log(transform.forward);			// �I�u�W�F�N�g��z��������\�����[���h�P�ʃx�N�g���i-0.35, 0.00, 0.94 �Ƃ��j
		//Debug.Log(rb.transform.forward);		// ��L�ɓ���
		//Debug.Log(Vector3.forward);			// 0,0,1�ŌŒ�i���[�J�����W�l�ł��邽�߁j
	}

	private void Jump() {
		gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, ForceAscent, 0f), ForceMode.Impulse);
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

		rb.transform.Rotate(new Vector3(0f, turnSpeedY, 0f));
		PlayerCamera.transform.Rotate(new Vector3(turnSpeedX, 0f, 0f));
	}

	/* ��//��//�� �J�����ړ����o�[�W���� ��//��//��

	private void ChangeAngle() {
		var	  mousePos	 = MainCamera.ScreenToViewportPoint(Input.mousePosition);
		float turnSpeedY = 0f;
		float absAngleY	 = Mathf.Abs(mousePos.x - 0.5f);    // 0.0 �` 0.5
		float turnSpeedX = 0f;
		float absAngleX	 = Mathf.Abs(mousePos.y - 0.5f);    // 0.0 �` 0.5

		if (absAngleY > 0.02) {
			turnSpeedY = (absAngleY * SpeedTurnIncreaseRateY) * MaxSpeedTurnY;
			if (mousePos.x < 0.5)
				turnSpeedY *= -1;
			if (turnSpeedY > MaxSpeedTurnY)
				turnSpeedY = MaxSpeedTurnY;
			if (turnSpeedY < -1 * MaxSpeedTurnY)
				turnSpeedY = -1 * MaxSpeedTurnY;
		}
		if (absAngleX > 0.02) {
			turnSpeedX = (absAngleX * SpeedTurnIncreaseRateY) * MaxSpeedTurnY;
			if (mousePos.y > 0.5)
				turnSpeedX *= -1;
			if (turnSpeedX > MaxSpeedTurnX)
				turnSpeedX = MaxSpeedTurnX;
			if (turnSpeedX < -1 * MaxSpeedTurnX)
				turnSpeedX = -1 * MaxSpeedTurnX;

			var angle = MainCamera.transform.eulerAngles.x;
			if (   angle > 70 && angle < 180 && turnSpeedX > 0	// ����]���~�߂�
				|| angle < 360 - 70 && angle > 180 && turnSpeedX < 0)			// ���]���~�߂�
				turnSpeedX = 0f;
		}
		rb.angularVelocity = new Vector3(0f, turnSpeedY, 0f);
		MainCamera.transform.Rotate(new Vector3(turnSpeedX, 0f, 0f));
		//Debug.Log("PlayerAngleY: " + transform.eulerAngles.y);
		//Debug.Log("PlayerAngleY (rotate): " + transform.rotation.y);
	}
	*/
}

// transform.eulerAngles �́A0�`360�̒l��Ԃ��B���ɑ΂��āA�E�˂������Ō�������B
// �E�˂��̋t�ő����Ă����̂ł���B

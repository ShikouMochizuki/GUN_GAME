using UnityEngine;

// Groundタグがついたオブジェクトを地形として認識する。
// 接触やジャンプの判定で使用
public class Player : MonoBehaviour {

	public float MaxSpeedHorizontal = 4f;   // 水平方向最高速度
	public float MaxAscentSpeed = 0.15f;    // 最高上昇速度
	public float MaxFallSpeed = 0.2f;       // 最高落下速度

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
		// 入力を元に力を加える
		var ForceH = new Vector3(0f, 0f, 0f);
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

		// 力を加える
		rb.AddForce(transform.rotation * ForceH);
		//Debug.Log(transform.forward);			// オブジェクトのz軸方向を表すワールド単位ベクトル（-0.35, 0.00, 0.94 とか）
		//Debug.Log(rb.transform.forward);		// 上記に同じ
		//Debug.Log(Vector3.forward);			// 0,0,1で固定（ローカル座標値であるため）
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
		if (   angle > 70       && angle < 180 && turnSpeedX > 0	// 下回転を止める
			|| angle < 360 - 70 && angle > 180 && turnSpeedX < 0)	// 上回転を止める
			turnSpeedX = 0f;

		rb.transform.Rotate(new Vector3(0f, turnSpeedY, 0f));
		PlayerCamera.transform.Rotate(new Vector3(turnSpeedX, 0f, 0f));
	}

	/* ■//■//■ カメラ移動旧バージョン ■//■//■

	private void ChangeAngle() {
		var	  mousePos	 = MainCamera.ScreenToViewportPoint(Input.mousePosition);
		float turnSpeedY = 0f;
		float absAngleY	 = Mathf.Abs(mousePos.x - 0.5f);    // 0.0 ～ 0.5
		float turnSpeedX = 0f;
		float absAngleX	 = Mathf.Abs(mousePos.y - 0.5f);    // 0.0 ～ 0.5

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
			if (   angle > 70 && angle < 180 && turnSpeedX > 0	// 下回転を止める
				|| angle < 360 - 70 && angle > 180 && turnSpeedX < 0)			// 上回転を止める
				turnSpeedX = 0f;
		}
		rb.angularVelocity = new Vector3(0f, turnSpeedY, 0f);
		MainCamera.transform.Rotate(new Vector3(turnSpeedX, 0f, 0f));
		//Debug.Log("PlayerAngleY: " + transform.eulerAngles.y);
		//Debug.Log("PlayerAngleY (rotate): " + transform.rotation.y);
	}
	*/
}

// transform.eulerAngles は、0～360の値を返す。軸に対して、右ねじ方向で減少する。
// 右ねじの逆で増えていくのである。

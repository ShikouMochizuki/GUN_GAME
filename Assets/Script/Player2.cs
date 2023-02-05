using UnityEngine;

// Groundタグがついたオブジェクトを地形として認識する。
// 接触やジャンプの判定で使用
public class Player2 : MonoBehaviour {

	public float MaxSpeedWalk  = 0.09f;	// 水平方向最高速度（ウォーク）
	public float MaxSpeedRun   = 0.14f;	// 酸い方向最高速度（ダッシュ）
	public float AccHorizontal = 0.04f;	// 水平方向加速度
	public float DecFriction   = 0.02f; // 摩擦による減速方向の加速度

	public float MaxSpeedVertical = 0.13f;	// 垂直方向最高速度
	public float AscentSpeed	  = 0.13f;	// ジャンプ時の上昇速度
	public int   JumpPower		  = 30;		// ジャンプ力（数値が高いほど高く跳べる）
	public float AccGravity		  = 0.005f;	// 重力加速度

	public float TurnSpeedY = 3.5f;		// カメラのY軸に対する回転速度
	public float TurnSpeedX = 3.5f;		// カメラのX軸に対する回転速度

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
			Move();
		}
	}

	private void Move() {

		// 水平方向の速度が極端に小さい場合は静止させる
		Vector3 moveTmp;	// 冗長な書き方だが、ディープコピーするにはこうするしかないのかも
		moveTmp.x = move.x;
		moveTmp.y = move.y;
		moveTmp.z = move.z;
		//Debug.Log(move.x);
		//Debug.Log(Mathf.Abs(move.x));
		if (Mathf.Abs(move.x) < 0.03)
			moveTmp.x = 0f;
		if (Mathf.Abs(move.z) < 0.03)
			moveTmp.z = 0f;

		// 移動
		cc.Move(transform.TransformDirection(moveTmp));
	}

	private void OperateVelocityHorizontal() {
		
		// 入力を元に水平方向へ加速
		if (Input.GetKey(KeyCode.W)) move.z += AccHorizontal;
		if (Input.GetKey(KeyCode.D)) move.x += AccHorizontal;
		if (Input.GetKey(KeyCode.S)) move.z += -1f * AccHorizontal;
		if (Input.GetKey(KeyCode.A)) move.x += -1f * AccHorizontal;
		if (cc.isGrounded) {
			// 摩擦による減速
			if (move.x > 0) move.x -= DecFriction;
			else			move.x += DecFriction;
			if (move.z > 0) move.z -= DecFriction;
			else			move.z += DecFriction;
		}

		// 最高速度を決定（WALKとRUNで異なる）
		float SpeedLimit;
		if (Input.GetMouseButton(1))
			SpeedLimit = MaxSpeedRun;
		else
			SpeedLimit = MaxSpeedWalk;

		// 水平方向の速度制限
		float vSpeedHorizontal = Mathf.Sqrt(move.x * move.x + move.z * move.z);
		if (vSpeedHorizontal > SpeedLimit) {
			var unitVec = new Vector3(
				move.x / vSpeedHorizontal,
				0f,
				move.z / vSpeedHorizontal
			);
			move = new Vector3(
				unitVec.x * SpeedLimit,
				move.y,
				unitVec.z * SpeedLimit
			);
		}
	}

	private void OperateVelocityVertical() {
		// ジャンプ
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

		// 重力
		move.y -= AccGravity;

		// 垂直方向の速度制限
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
		if (   angle > 70       && angle < 180 && turnSpeedX > 0	// 下回転を止める
			|| angle < 360 - 70 && angle > 180 && turnSpeedX < 0)	// 上回転を止める
			turnSpeedX = 0f;

		//transform.Rotate(new Vector3(0f, turnSpeedY, 0f));
		cc.transform.Rotate(new Vector3(0f, turnSpeedY, 0f));
		PlayerCamera.transform.Rotate(new Vector3(turnSpeedX, 0f, 0f));
	}
}

// transform.eulerAngles は、0～360の値を返す。軸に対して、右ねじ方向で減少する。
// 右ねじの逆で増えていくのである。

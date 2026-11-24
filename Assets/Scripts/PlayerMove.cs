using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics2D;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float moveSpeed =7f;
	
	// 感性
	[SerializeField] float acceleration = 30f; // 加速
	[SerializeField] float deceleration = 20f; // 減速



	Inputs inputs;
	CharacterController controller;

	Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // コンポーネント取得
		inputs = GetComponent<Inputs>();
		controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		// カメラの平面ベクトルを作成
		Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

		// カメラの向きを考慮した移動量
		Vector3 planeVel = (cameraForward * inputs.move.y + Camera.main.transform.right * inputs.move.x)*moveSpeed;

		// 移動中、進行方向にゆっくり向く
		if(inputs.move != Vector2.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(planeVel.normalized), 0.2f);
		}

		//// 移動速度
		//planeVel *= moveSpeed;
		// 移動量
		//velocity.x = planeVel.x;
		//velocity.z = planeVel.z;


		// 現在の速度
		Vector3 currentPlaneVel = new Vector3(velocity.x, 0, velocity.z);

		// 入力がある時は加速、ない時は減速
		float rate; 
		if (inputs.move != Vector2.zero)
		{
			// 加速
			rate = acceleration;
		}
		else
		{
			// 減速
			rate = deceleration;
		}

		// 現在の速度から目標速度へ徐々に近づける
		currentPlaneVel = Vector3.MoveTowards(currentPlaneVel, planeVel, rate * Time.deltaTime);

		// 計算した速度をvelocityに反映
		velocity.x = currentPlaneVel.x;
		velocity.z = currentPlaneVel.z;

		// 落下
		if (controller.isGrounded)
		{
			velocity.y = 0;
		}
		else
		{
			velocity.y += Physics.gravity.y * Time.deltaTime;
		}

		// 移動
		controller.Move(velocity * Time.deltaTime);
    }
}

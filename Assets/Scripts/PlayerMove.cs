using UnityEngine;
using UnityEngine.LowLevelPhysics2D;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float moveSpeed = 10;

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
        // 移動量
		velocity.x = inputs.move.x * moveSpeed;
		velocity.z = inputs.move.y * moveSpeed;

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

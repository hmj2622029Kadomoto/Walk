using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
	[SerializeField] float maxSpeed = 10f;
	[SerializeField] float maxInterval = 1f;
	[SerializeField] float decaySpeed = 5f;

	Rigidbody rbody;

	float lastPressTime = -1f;
	float currentSpeed = 0f;

	void Start()
	{
		rbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Keyboard.current.wKey.wasPressedThisFrame)
		{
			float now = Time.time;

			if (lastPressTime >= 0f)
			{
				// ‘O‰ñ‚Ì“ü—Í‚©‚ç‚ÌŠÔŠu
				float interval = now - lastPressTime;

				if (interval < maxInterval)
				{
					// ŠÔŠu‚ª1•b‚É‹ß‚¢‚Ù‚Ç‘¬“x‚ðã‚°‚é
					float ratio = interval / maxInterval;

					currentSpeed = Mathf.Lerp(0f, maxSpeed, ratio);
				}
				else
				{
					// 1•bˆÈã‚È‚ç‘¬“x0
					currentSpeed = 0f;
				}
			}

			lastPressTime = now;
		}

		// ŽžŠÔŒo‰ß‚Æ‚Æ‚à‚É‘¬“x‚ð‰º‚°‚é
		currentSpeed = Mathf.MoveTowards(currentSpeed,0f,decaySpeed * Time.deltaTime);
	}

	void FixedUpdate()
	{
		// ‘O•ûŒü‚ÉˆÚ“®
		Vector3 velocity = rbody.linearVelocity;

		velocity.x = transform.forward.x * currentSpeed;
		velocity.z = transform.forward.z * currentSpeed;

		rbody.linearVelocity = velocity;
	}
}

using UnityEngine;

public class GhostController : MonoBehaviour
{
	enum GhostType
	{
		LeftRight,
		UpDown,
		ForwardBack,
		Circle,
		Approach,
		Teleport
	}

	[SerializeField] float moveSpeed = 2f;
	[SerializeField] float teleportInterval = 2f;
	[SerializeField] float distance = 0f;
	[SerializeField] AudioClip SE;

	AudioSource audioSource;

	Transform M_Trap;
	Transform target;

	GhostType ghostType;

	float angle;
	float teleportTimer;

	Vector3 circleCenter;

	private void Start()
	{
		GetComponent<ParticleSystem>().Play();
		audioSource = GetComponent<AudioSource>();

		// 初期位置を保存
		circleCenter = transform.position;
	}

	public void Initialize(Transform Trap,Transform Player)
	{
		M_Trap = Trap;
		target = Player;

		// 6種類からランダム選択
		ghostType = (GhostType)Random.Range(0, 6);

		circleCenter = transform.position;
	}

	void Update()
	{
		if (target == null)
			return;

		angle += moveSpeed * Time.deltaTime;

		float wave = Mathf.Sin(angle);

		switch(ghostType)
		{
			case GhostType.LeftRight:
				// 左右
				transform.position = circleCenter + new Vector3(Mathf.Cos(angle) * distance, 0f, 0f);
				break;
			case GhostType.UpDown:
				// 上下				
				transform.position = circleCenter + new Vector3(0f, Mathf.Cos(angle) * distance, 0f);

				break;
			case GhostType.ForwardBack:
				// 前後				
				transform.position = circleCenter + new Vector3(0f, 0f, Mathf.Cos(angle) * distance);

				break;
			case GhostType.Circle:
				// 円運動
				transform.position = circleCenter + new Vector3(Mathf.Cos(angle) * distance, 0f, Mathf.Sin(angle) * distance);
				break;
			case GhostType.Approach:
				// 接近・後退
				Vector3 direction = (target.position - circleCenter).normalized;
				transform.position = circleCenter + direction * wave * distance;
				break;
			case GhostType.Teleport:
				// 瞬間移動
				teleportTimer += Time.deltaTime;
				if(teleportTimer >= teleportInterval)
				{
					Teleport();
					teleportTimer = 0f;
				}
				break;
		}

		// プレイヤーの方を向く
		Vector3 dir = target.position - transform.position;
		dir.y = 0f;

		if(dir != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(dir);
		}
	}
	void Teleport()
	{
		GetComponent<ParticleSystem>().Play();
		audioSource.PlayOneShot(SE);
		// プレイヤー周囲のランダムな方向
		float randomAngle = Random.Range(0f, 360f);

		Vector3 direction = new Vector3(Mathf.Cos(randomAngle*Mathf.Deg2Rad),0f,Mathf.Sin(randomAngle*Mathf.Deg2Rad));

		// プレイヤーから離れた場所に移動
		float randomDistance = Random.Range(3f, 6f);
		Vector3 newPosition = target.position + direction * randomDistance;
		newPosition.y = circleCenter.y;
		transform.position = newPosition;
	}
}
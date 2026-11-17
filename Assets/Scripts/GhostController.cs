using UnityEngine;

public class GhostController : MonoBehaviour
{
	[SerializeField] Transform Trap;
	[SerializeField] float rotateSpeed = 90f;
	[SerializeField] float GhostX = 1f;
	[SerializeField] float GhostY = 1f;
	[SerializeField] float GhostZ = 1f;

	[SerializeField] float distance = 0f;
	float angle;

	void Start()
	{
		Transform target = Trap;
	}

	void Update()
	{
		if (Trap == null)
			return;

		angle += rotateSpeed * Time.deltaTime;
		// Trap‚ğ‹N“_‚Æ‚µ‚Äã‰º‰^“®‚ğ‚·‚é
		Vector3 offset = new Vector3( Mathf.Cos(angle * Mathf.Deg2Rad) - GhostX,GhostY, GhostZ) * distance;
		transform.position = Trap.position + offset;
	}
}
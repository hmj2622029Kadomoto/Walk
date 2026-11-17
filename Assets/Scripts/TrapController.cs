using UnityEngine;

public class TrapController : MonoBehaviour
{
	void Start()
	{

	}
	void OnTriggerEnter(Collider other)
	{
		GameObject Ghost = Instantiate(GhostPrefab, transform.position, transform.rotation);
	}
}
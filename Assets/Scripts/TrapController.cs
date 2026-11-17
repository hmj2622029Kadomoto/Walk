using UnityEngine;

public class TrapController : MonoBehaviour
{
	[SerializeField] GameObject GhostPrefab;
	void Start()
	{

	}
	void OnTriggerEnter(Collider other)
	{
		GameObject Ghost = Instantiate(GhostPrefab, transform.position, transform.rotation);
	}
}
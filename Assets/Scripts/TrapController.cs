using UnityEngine;

public class TrapController : MonoBehaviour
{
	[SerializeField] GameObject[] GhostPrefab;
	[SerializeField] Transform GhostSpawnPoint;

	GameObject currentGhost;

	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player"))
			return;
		if (currentGhost != null)
			return;
		int index = Random.Range(0, GhostPrefab.Length);
		currentGhost = Instantiate(GhostPrefab[index], GhostSpawnPoint.position, Quaternion.identity);
		currentGhost.GetComponent<GhostController>().Initialize(transform,other.transform);
	}
	private void OnTriggerExit(Collider other)
	{
		if (!other.CompareTag("Player"))
			return;
		if (currentGhost == null)
			return;

		Destroy(currentGhost);
		currentGhost = null;
	}
}

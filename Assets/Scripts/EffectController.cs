using UnityEngine;

public class EffectController : MonoBehaviour
{
	ParticleSystem particle;
	private void Start()
	{
		particle = GetComponent<ParticleSystem>();
		particle.Play();
	}
	private void Update()
	{
		if(!particle.IsAlive())
		{
			Destroy(gameObject);
		}
	}
}

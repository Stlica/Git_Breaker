using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_SpeParth : MonoBehaviour
{
	public ParticleSystem particleSystem2;
	public GameObject player;
	private P2_Controller_Platform player2Controller;

	// Start is called before the first frame update
	void Start()
	{
		player2Controller = player.GetComponent<P2_Controller_Platform>();

		StopParticles2();
	}

	// Update is called once per frame
	void Update()
	{
		if (player2Controller.Special)
		{
			PlayParticles2();
		}
		else
		{
			StopParticles2();
		}
	}

	public void PlayParticles2()
	{
		if (particleSystem2 != null && !particleSystem2.isPlaying)
		{
			particleSystem2.Play();
		}
	}

	public void StopParticles2()
	{
		if (particleSystem2 != null && particleSystem2.isPlaying)
		{
			particleSystem2.Stop();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeParth : MonoBehaviour
{
	public ParticleSystem particleSystem2;
	public GameObject player1;
	private P_Controller_Platform player1Controller;

	// Start is called before the first frame update
	void Start()
	{
		player1Controller = player1.GetComponent<P_Controller_Platform>();

		StopParticles2();
	}

	// Update is called once per frame
	void Update()
	{
		if (player1Controller.Special)
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

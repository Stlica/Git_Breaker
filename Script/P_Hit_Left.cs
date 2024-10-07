using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Hit_Left : MonoBehaviour
{
	public ParticleSystem Parth;
	public GameObject player1;
	private P_Controller_Platform player1Controller;

	private void Start()
	{
		Parth.Stop();
		player1Controller = player1.GetComponent<P_Controller_Platform>();
	}

	//オブジェクトと接触した瞬間に呼び出される
	private void OnTriggerEnter(Collider other)
	{
		// 攻撃した相手がEnemyの場合
		if ((other.gameObject.layer == 12 || other.gameObject.layer == 16) && player1Controller.isAnim)
		{
			ParticleSystem particles = Instantiate(Parth, transform.position, Quaternion.identity);
			particles.Play();
			StartCoroutine(DestroyParticleAfterDelay(particles, 0.2f));
			Debug.Log("hit_HandP1  " + other.gameObject.tag);
		}

		// 攻撃した相手がPlayerの場合
		if (other.gameObject.layer == 13 && player1Controller.isAnim)
		{
			ParticleSystem particles2 = Instantiate(Parth, transform.position, Quaternion.identity);
			particles2.Play();
			StartCoroutine(DestroyParticleAfterDelay(particles2, 0.2f));
			Debug.Log("hit_HandP1  " + other.gameObject.tag);
		}
	}

	IEnumerator DestroyParticleAfterDelay(ParticleSystem particles, float delay)
	{
		yield return new WaitForSeconds(delay);
		Destroy(particles.gameObject);
	}
}
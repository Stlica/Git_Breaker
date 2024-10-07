using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Hit_Right : MonoBehaviour
{
	public ParticleSystem Parth;
	public GameObject player2;
	private P2_Controller_Platform player2Controller;

	private void Start()
	{
		Parth.Stop();
		player2Controller = player2.GetComponent<P2_Controller_Platform>();
	}

	//オブジェクトと接触した瞬間に呼び出される
	private void OnTriggerEnter(Collider other)
	{
		// 攻撃した相手がEnemyの場合
		if ((other.gameObject.layer == 12 || other.gameObject.layer == 16) && player2Controller.isAnim)
		{
			ParticleSystem particles = Instantiate(Parth, transform.position, Quaternion.identity);
			particles.Play();
			StartCoroutine(DestroyParticleAfterDelay(particles, 0.2f));
			Debug.Log("hit_HandP1  " + other.gameObject.tag);
		}

		// 攻撃した相手がPlayerの場合
		if (other.gameObject.layer == 9 && player2Controller.isAnim)
		{
			ParticleSystem particles2 = Instantiate(Parth, transform.position, Quaternion.identity);
			particles2.Play();
			StartCoroutine(DestroyParticleAfterDelay(particles2, 0.2f));
			Debug.Log("hit_HandP2  " + other.gameObject.tag);
		}
	}

	IEnumerator DestroyParticleAfterDelay(ParticleSystem particles, float delay)
	{
		yield return new WaitForSeconds(delay);
		Destroy(particles.gameObject);
	}
}
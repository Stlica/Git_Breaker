using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_GroundCheck : MonoBehaviour
{
	private GameObject target;
	private P_Controller_Platform playerController;
	//public bool isGround;

	// Start is called before the first frame update
	void Start()
    {
		target = GameObject.Find("Player1_Fighter");
		playerController = target.GetComponent<P_Controller_Platform>();
		//groundChecker = GameObject.Find("isGround").GetComponent<GameObject>();
		//isGround = true;
	}

    // Update is called once per frame
    void Update()
    {}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("ground"))
		{
			//Debug.Log("aaa");
			playerController.isGround = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("ground"))
		{
			//Debug.Log("b");
			playerController.isGround = false;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		//Debug.Log("aaa" + other.tag);

		if (other.CompareTag("ground"))
		{
			//Debug.Log("aaa");
			playerController.isGround = true;
		}
	}
}

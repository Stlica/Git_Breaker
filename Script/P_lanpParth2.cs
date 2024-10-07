using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_lanpParth2 : MonoBehaviour
{
    public ParticleSystem lanpAttack;
    public GameObject player1;
    private P_Controller_Platform player1Controller;
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        player1Controller = player1.GetComponent<P_Controller_Platform>();

        StopParticles();
    }

    // Update is called once per frame
    void Update()
    {
        weapon = player1Controller.GetWeapon();


        if (player1Controller.isAttack && player1Controller.isAttack2 && weapon != null && weapon.CompareTag("Item"))
        {
            StartCoroutine(WaitBefore(0.2f));

        }
        else
        {
            StopParticles();
        }
    }

    public void PlayParticles()
    {
        if (lanpAttack != null && !lanpAttack.isPlaying)
        {
            lanpAttack.Play();
        }
    }

    public void StopParticles()
    {
        if (lanpAttack != null && lanpAttack.isPlaying)
        {
            lanpAttack.Stop();
        }
    }

    IEnumerator WaitBefore(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PlayParticles();
    }
}

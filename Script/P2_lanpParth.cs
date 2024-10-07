using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_lanpParth : MonoBehaviour
{
    public ParticleSystem lanpAttack;
    public GameObject player2;
    private P2_Controller_Platform player2Controller;
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        player2Controller = player2.GetComponent<P2_Controller_Platform>();

        StopParticles();
    }

    // Update is called once per frame
    void Update()
    {
        weapon = player2Controller.GetWeapon();


        if (player2Controller.isAttack && player2Controller.isAttack1 && weapon != null && weapon.CompareTag("Item"))
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

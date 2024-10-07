using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnTargetDetector : MonoBehaviour
{

    [SerializeField]
    private GameObject target;

    protected void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            target = c.gameObject;
        }
    }

    protected void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    public GameObject getTarget()
    {
        return this.target;
    }
}

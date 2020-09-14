using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Checkpoint : MonoBehaviour
{
    private SphereCollider coll;

    private void Reset()
    {
        coll = this.GetComponent<SphereCollider>();
    }

    private void Awake()
    {
        coll = this.GetComponent<SphereCollider>();
    }

    private void OnDrawGizmos()
    {
        if (coll != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(coll.transform.position, coll.radius);
            Gizmos.color = Color.white;
        }

        
    }
}

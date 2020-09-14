using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    [SerializeField] private Transform[] checkPoints;

    private void Awake()
    {
        checkPoints = this.GetComponentsInChildren<Transform>();
    }

    private void Reset()
    {
        checkPoints = this.GetComponentsInChildren<Transform>();
    }

    private void OnDrawGizmos()
    {
        if (checkPoints != null && checkPoints.Length > 0)
        {
            for (int i = 0; i < checkPoints.Length; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(checkPoints[i].position,this.transform.lossyScale.x);
                Gizmos.color = Color.white;
            }
        }


    }

}

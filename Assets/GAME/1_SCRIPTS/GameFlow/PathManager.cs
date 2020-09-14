using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PathManager : MonoBehaviour
{
    [SerializeField] private Transform[] pathPoints;
    
    public Transform[] GetLevelPath()
    {
        return pathPoints;
    }

    private void Awake()
    {
        pathPoints = this.GetComponentsInChildren<Transform>();
    }

    private void Reset()
    {
        pathPoints = this.GetComponentsInChildren<Transform>();
    }

    private void OnDrawGizmos()
    {
        if (pathPoints.Length > 0)
        {
            for (int i = 0; i < pathPoints.Length - 1; i++)
            {
                Gizmos.color = i % 2 == 0 ? Color.black : Color.red;
                Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
                Gizmos.color = Color.white;
            }
        }

        
    }
}

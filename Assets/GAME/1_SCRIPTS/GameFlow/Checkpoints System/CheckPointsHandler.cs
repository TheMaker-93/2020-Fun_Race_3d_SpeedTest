using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsHandler : MonoBehaviour
{
    [SerializeField] private Checkpoint latestActivatedCheckpoint;

    public Checkpoint GetLatestCheckpoint ()
    {
        return latestActivatedCheckpoint;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == GameController.instance.GetCheckpointTag())
        {
            Checkpoint cp = other.GetComponent<Checkpoint>();
            if (cp == null)
                Debug.LogError("The checkpoint needs to have deffined a Checkpoint script");
            else
                latestActivatedCheckpoint = cp;
        }
        
    }

}

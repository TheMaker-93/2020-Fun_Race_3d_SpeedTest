using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public abstract class CameraAnimationTrigger : MonoBehaviour
{
    protected abstract void ProcessTriggerEnter(CameraAnimationController cam);
    protected abstract void ProcessTriggerExit(CameraAnimationController cam);

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == GameController.instance.GetPlayerTag())
        {
            CameraAnimationController camAnimationController = other.GetComponentInChildren<CameraAnimationController>();
            if (camAnimationController == null)
                Debug.LogError("No camera animation controller found on player");
            
            ProcessTriggerEnter(camAnimationController);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == GameController.instance.GetPlayerTag())
        {
            CameraAnimationController camAnimationController = other.GetComponentInChildren<CameraAnimationController>();
            ProcessTriggerExit(camAnimationController);
        }
    }

    

}

using UnityEngine;

public class RemoteTrigger : RemoteCollision
{
    [SerializeField] private UnityTriggerEvent OnEnter;
    [SerializeField] private UnityTriggerEvent OnStay;
    [SerializeField] private UnityTriggerEvent OnExit;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    public UnityTriggerEvent GetOnEnterEvent()
    {
        return OnEnter;
    }
    public UnityTriggerEvent GetOnExitEvent()
    {
        return OnExit;
    }
    public UnityTriggerEvent GetOnStayEvent()
    {
        return OnStay;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (OnEnter != null && collider.transform.tag == TagToFilter)            // check if valid (does it have any listener?)
            OnEnter.Invoke(collider);
    }
    
    private void OnTriggerStay(Collider collider)
    {
        if (OnStay != null && collider.transform.tag == TagToFilter)             // check if valid (does it have any listener?)
            OnStay.Invoke(collider);
    }
    private void OnTriggerExit(Collider collider)
    {
        if (OnExit != null && collider.transform.tag == TagToFilter)             // check if valid (does it have any listener?)
            OnExit.Invoke(collider);
    }

}

using UnityEngine;

public class RemoteCollider : RemoteCollision
{
    [SerializeField] private UnityColliderEvent OnEnter;
    [SerializeField] private UnityColliderEvent OnStay;
    [SerializeField] private UnityColliderEvent OnExit;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = false;
    }

    public UnityColliderEvent GetOnEnterEvent()
    {
        return OnEnter;
    }
    public UnityColliderEvent GetOnExitEvent()
    {
        return OnExit;
    }
    public UnityColliderEvent GetOnStayEvent()
    {
        return OnStay;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (OnEnter != null)            // check if valid (does it have any listener?)
            OnEnter.Invoke(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (OnStay != null)             // check if valid (does it have any listener?)
            OnStay.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (OnExit != null)             // check if valid (does it have any listener?)
            OnExit.Invoke(collision);
    }
}

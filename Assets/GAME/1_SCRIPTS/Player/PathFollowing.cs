using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterInput))]
public class PathFollowing : MonoBehaviour
{
    [SerializeField] private CharacterInput characterInput;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform[] pathToFollow;
    [SerializeField] private int currentPointToRreachIndex;

    [SerializeField] private bool active = false;
    [SerializeField] private float reachDistanceThreshold;
    [SerializeField] private float movementSpeed;

    public void SetActiveState(bool _newState)
    {
        active = _newState;
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();

        characterInput = this.GetComponent<CharacterInput>();
    }

    public void Setpath(Transform[] _levelPath)
    {
        pathToFollow = _levelPath;
    }

    private void Start()
    {
        characterInput.OnInputButtonDown.AddListener(SetActiveState);
        characterInput.OnInputButtonUp.AddListener(SetActiveState);
    }

    private void FixedUpdate()
    {
        if (active == true && currentPointToRreachIndex < pathToFollow.Length )
            MoveToNextPoint();
        else
            StopMovement();
    }

    public void MoveToNextPoint ()
    {
        Vector3 vectorToNextPoint = pathToFollow[currentPointToRreachIndex].position - this.transform.position;

        Vector3 directionToNextPoint = vectorToNextPoint.normalized;

        Vector3 newVelocity = directionToNextPoint * movementSpeed * Time.fixedDeltaTime;
        newVelocity.y = rb.velocity.y;
        rb.velocity = directionToNextPoint * movementSpeed * Time.fixedDeltaTime;

        RotateToNextPoint();

        float currentDistance = vectorToNextPoint.magnitude;
        if (currentDistance <= reachDistanceThreshold)
        {
            // point reached
            IncreaseTargetIndex();
        }
    }

    private void RotateToNextPoint()
    {
        Debug.LogError("Temporal");
        this.transform.forward = pathToFollow[currentPointToRreachIndex].transform.forward;

    }

    private void StopMovement ()
    {
        Vector3 newVelocity = new Vector3();
        newVelocity.x = 0;
        newVelocity.y = rb.velocity.y;
        newVelocity.z = 0;

        rb.velocity = newVelocity;
    }

    private void IncreaseTargetIndex ()
    {

        if (currentPointToRreachIndex >= pathToFollow.Length)
        {
            Debug.Log("Path end reached");
        }
        else
        {
            currentPointToRreachIndex++;
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 5f);
    }

}

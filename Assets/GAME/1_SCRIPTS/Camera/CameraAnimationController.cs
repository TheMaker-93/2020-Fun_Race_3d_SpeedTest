using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int centerToRightIndex = 1;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public void PlayCenterToRightAnimation()
    {
        animator.SetInteger("animationIndex", centerToRightIndex);
    }
    public void ResetCenteredView()
    {
        animator.SetInteger("animationIndex", centerToRightIndex * -1);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private bool enabled = true;
    [SerializeField] private bool isButtonBeingPressed;
    [SerializeField] private PathFollowing pathFollowingController;

    public InputPressedEvent OnInputButtonDown;
    public InputPressedEvent OnInputButtonUp;

    private void Awake()
    {
        if (OnInputButtonDown == null)
            OnInputButtonDown = new InputPressedEvent();
        if (OnInputButtonUp == null)
            OnInputButtonUp = new InputPressedEvent();
    }

    internal void DisableInputs()
    {
        enabled = false;
    }
    internal void EnableInputs()
    {
        enabled = true;
    }

    private void Update()
    {
        if (enabled)
        {
            if (Input.GetMouseButton(0))
            {
                isButtonBeingPressed = true;

                OnInputButtonDown?.Invoke(isButtonBeingPressed);
            }
            else
            {
                isButtonBeingPressed = false;

                OnInputButtonUp?.Invoke(isButtonBeingPressed);
            }
        }

        

    }


}

[System.Serializable]
public class InputPressedEvent : UnityEvent<bool>
{

}

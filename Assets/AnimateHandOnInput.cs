using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimAction;
    public InputActionProperty gripAnimAction;
    public Animator handAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimAction.action.ReadValue<float>();
        handAnim.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimAction.action.ReadValue<float>();
        handAnim.SetFloat("Grip", gripValue);
    }
}

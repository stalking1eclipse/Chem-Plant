using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DynamicAttachPoint : XRGrabInteractable
{
    private Transform originalAttachTransform;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Store the original attach transform for reference
        originalAttachTransform = attachTransform;

        // Calculate and set the dynamic attach point
        CalculateDynamicAttachPoint(args.interactorObject.transform);
    }

    private void CalculateDynamicAttachPoint(Transform handTransform)
    {
        // Get the relative position and rotation of the hand to the tool in the local space of the original attach point
        Vector3 relativePosition = originalAttachTransform.InverseTransformPoint(handTransform.position);
        Quaternion relativeRotation = Quaternion.Inverse(originalAttachTransform.rotation) * handTransform.rotation;

        // Adjust the attach point based on the hand's orientation
     
        Vector3 newAttachPosition = CalculateNewAttachPosition(relativePosition);
        Quaternion newAttachRotation = CalculateNewAttachRotation(relativeRotation);

        // Set the new attach point in world space
        attachTransform.position = originalAttachTransform.TransformPoint(newAttachPosition);
        attachTransform.rotation = originalAttachTransform.rotation * newAttachRotation;
    }

    private Vector3 CalculateNewAttachPosition(Vector3 relativePosition)
    {
        // implement some space transform logic here
        return relativePosition + Vector3.forward * 0.1f;
    }

    private Quaternion CalculateNewAttachRotation(Quaternion relativeRotation)
    {
        //implement some rotation logic here
        return relativeRotation;
    }
}

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    [SerializeField]
    private Transform LeftAttchPointTransform;
    [SerializeField]
    private Transform RightAttchPointTransform;
    // Start is called before the first frame update
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        //attachTransform.position = args.interactorObject.transform.position;
        //attachTransform.rotation = args.interactorObject.transform.rotation;
        base.OnSelectEntered(args);
        if (args.interactorObject.transform.CompareTag("Left Hand"))
        {
            if (LeftAttchPointTransform)
            {
                attachTransform = LeftAttchPointTransform;
            }
            //else
            {
        
            }

        }
        else if (args.interactorObject.transform.CompareTag("Right Hand"))
        {
            if (LeftAttchPointTransform)
            {
                attachTransform = RightAttchPointTransform;
            }
            //else
            //{
            //    attachTransform.position = args.interactorObject.transform.position;
            //    attachTransform.rotation = args.interactorObject.transform.rotation;
            //}
            //attachTransform = RightAttchPointTransform;
        }

    }
}

using UnityEngine;
using UnityEngine.InputSystem;
public class MenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2;
    public GameObject menu, Legend;
    public InputActionProperty showButton;
    public InputActionProperty showLegendButton;

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
        }

        menu.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * spawnDistance;

        menu.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
        menu.transform.forward *= -1;
    }
}

using UnityEngine;

public class InstructionUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject UsageAndHandlingUICanvas;

    [SerializeField]
    GameObject CareUICanvas;

    [SerializeField]
    GameObject StorageUICanvas;
    // Start is called before the first frame update

    public void activateUsageCanvas()
    {
        if (!UsageAndHandlingUICanvas.activeSelf)
            UsageAndHandlingUICanvas.SetActive(true);

        if (StorageUICanvas.activeSelf && CareUICanvas.activeSelf)
        {
            CareUICanvas.SetActive(false);
            StorageUICanvas.SetActive(false);
        }
    }
    
    public void activateCareCanvas()
    {
        if (!CareUICanvas.activeSelf)
            CareUICanvas.SetActive(true);

        if(StorageUICanvas.activeSelf && UsageAndHandlingUICanvas.activeSelf)
        {
            StorageUICanvas.SetActive(false);
            UsageAndHandlingUICanvas.SetActive(false);
        }
    }
    
    public void activateStorageCanvas()
    {
        if (!StorageUICanvas.activeSelf)
            StorageUICanvas.SetActive(true);

        if (CareUICanvas.activeSelf && UsageAndHandlingUICanvas.activeSelf)
        {
            CareUICanvas.SetActive(false);
            UsageAndHandlingUICanvas.SetActive(false);
        }
    }
}

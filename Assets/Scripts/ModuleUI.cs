using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModuleUI : MonoBehaviour
{
    [SerializeField]
    List<TextMeshProUGUI> textMeshProUGUI;

    [SerializeField]
    GameObject UICanvas;

    public void nextPage()
    {
        int index = 0;

        foreach (TextMeshProUGUI _textMeshProUGUI in textMeshProUGUI)
        {
            if (_textMeshProUGUI.enabled)
            {
                textMeshProUGUI[index + 1].enabled = true;
                textMeshProUGUI[index].enabled = false;
                break;
            }
            index++;
        }
    }

    public void prevPage()
    {
        int index = 0;

        foreach (TextMeshProUGUI _textMeshProUGUI in textMeshProUGUI)
        {
            try
            {
                if (_textMeshProUGUI.enabled)
                {
                    textMeshProUGUI[index - 1].enabled = true;
                    textMeshProUGUI[index].enabled = false;
                    break;
                }
                index++;
            }
            catch
            {

            }
        }
    }

    public void closeContent()
    {
        UICanvas.SetActive(false);
    }
}

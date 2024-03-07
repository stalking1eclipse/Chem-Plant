using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssessmentQnAs : MonoBehaviour
{
    [SerializeField]
    bool IsQuestion = false;

    [SerializeField]
    List<GameObject> textMeshProUGUI;

    [SerializeField]
    GameObject UICanvas, InstructionParentUICanvas;

    [SerializeField]
    ScoreTracker scoreTracker;

    bool OptionSelected = false;

    public void NextPage()
    {
        int index = 0;


        if (OptionSelected)
        {
            foreach (GameObject _textMeshProUGUI in textMeshProUGUI)
            {
                if (_textMeshProUGUI.activeSelf)
                {
                    textMeshProUGUI[index + 1].SetActive(true);
                    textMeshProUGUI[index].SetActive(false);
                    break;
                }
                index++;
            } 
        }
    }

    public void PrevPage()
    {
        int index = 0;

        if (OptionSelected)
        {
            foreach (GameObject _textMeshProUGUI in textMeshProUGUI)
            {
                try
                {
                    if (_textMeshProUGUI.activeSelf)
                    {
                        textMeshProUGUI[index - 1].SetActive(true);
                        textMeshProUGUI[index].SetActive(false);
                        break;
                    }
                    index++;
                }
                catch
                {

                }
            } 
        }
    }

    public void CloseContent()
    {
        UICanvas.SetActive(false);

        if (InstructionParentUICanvas && !InstructionParentUICanvas.activeSelf)
            InstructionParentUICanvas.SetActive(true);
    }

    public void IncorrectAnswer()
    {
        OptionSelected = true;
    }

    public void CorrectAnswer()
    {
        scoreTracker.totalScore += 1;
        OptionSelected = true;
    }
}

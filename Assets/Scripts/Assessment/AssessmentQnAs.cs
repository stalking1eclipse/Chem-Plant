using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssessmentQnAs : MonoBehaviour
{
    [SerializeField]
    List<GameObject> textMeshProUGUI;
    [SerializeField]
    GameObject UICanvas, 
        InstructionParentUICanvas, 
        CloseButton;

    [SerializeField]
    ScoreTracker scoreTracker;
    QuestionState questionState;

    private void Start()
    {
        questionState = GetComponentInChildren<QuestionState>();
    }

    private void Update()
    {
        Debug.Log(questionState.name + " is active: " + questionState.transform.gameObject.activeSelf);

        if (scoreTracker.QuestionsAnswered >= 20)
            if (!CloseButton.activeSelf)
                CloseButton.SetActive(true);
    }

    public void NextPage()
    {
        int index = 0;

        if (!questionState.transform.gameObject.activeSelf)
        {
            questionState = GetComponentInChildren<QuestionState>();
        }

        if (questionState.OptionSelected && questionState.transform.gameObject.activeSelf)
        {
            foreach (GameObject _textMeshProUGUI in textMeshProUGUI)
            {
                try
                {
                    if (_textMeshProUGUI.activeSelf)
                    {
                        textMeshProUGUI[index + 1].SetActive(true);
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

    public void PrevPage()
    {
        int index = 0;

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

    public void CloseContent()
    {
        UICanvas.SetActive(false);

        if (InstructionParentUICanvas && !InstructionParentUICanvas.activeSelf)
            InstructionParentUICanvas.SetActive(true);
    }

    public void IncorrectAnswer()
    {
        if (!questionState.transform.gameObject.activeSelf)
        {
            questionState = GetComponentInChildren<QuestionState>();
        }

        if (!questionState.OptionSelected && questionState.transform.gameObject.activeSelf)
        {
            scoreTracker.QuestionsAnswered += 1;
        }

        questionState.OptionSelected = true;
        questionState.IsAnswerCorrect = false;
    }

    public void CorrectAnswer()
    {
        if (!questionState.transform.gameObject.activeSelf)
        {
            questionState = GetComponentInChildren<QuestionState>();
        }

        if ((!questionState.OptionSelected || !questionState.IsAnswerCorrect) && questionState.transform.gameObject.activeSelf)
        {
            scoreTracker.QuestionsAnswered += 1;
        }

        scoreTracker.TotalScore += 1;
        questionState.OptionSelected = true;
        questionState.IsAnswerCorrect = true;
    }
}

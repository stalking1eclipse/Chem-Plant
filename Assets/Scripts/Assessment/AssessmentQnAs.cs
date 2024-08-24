using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssessmentQnAs : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Questions;
    [SerializeField]
    GameObject  UICanvas,
                CloseButton;

    [SerializeField]
    TextMeshProUGUI TotalScoreText;
    [SerializeField]
    ScoreTracker scoreTracker;
    QuestionState questionState;

    bool QuestionnaireComplete = false;

    private void Start()
    {
        questionState = GetComponentInChildren<QuestionState>();
    }

    private void Update()
    {
        Debug.Log(questionState.name + " is active: " + questionState.transform.gameObject.activeSelf);
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
            foreach (GameObject _textMeshProUGUI in Questions)
            {
                try
                {
                    if (_textMeshProUGUI.activeSelf)
                    {
                        Questions[index + 1].SetActive(true);
                        Questions[index].SetActive(false);
                        break;
                    }
                    index++;
                }
                catch
                {

                }                
            } 
        }

        if (scoreTracker.QuestionsAnswered >= Questions.Count)
            if (!CloseButton.activeSelf)
                CloseButton.SetActive(true);
    }

    public void PrevPage()
    {
        int index = 0;

        foreach (GameObject _textMeshProUGUI in Questions)
        {
            try
            {
                if (_textMeshProUGUI.activeSelf)
                {
                    Questions[index - 1].SetActive(true);
                    Questions[index].SetActive(false);
                    break;
                }
                index++;
            }
            catch
            {

            }
        }

        if (CloseButton.activeSelf)
            CloseButton.SetActive(false);
    }

    public void CloseContent()
    {
        int index = 0;
        
        if (!QuestionnaireComplete)
        {
            Questions[Questions.Count-1].SetActive(false);
            Questions[0].SetActive(true);

            foreach (GameObject _textMeshProUGUI in Questions)
            {
                try
                {
                    Button[] correctAns = _textMeshProUGUI.GetComponentsInChildren<Button>();
                    foreach (Button button in correctAns)
                    {
                        if (button.name.Contains("--"))
                        {
                            ColorBlock colorBlock = button.colors;
                            colorBlock.normalColor = Color.green;
                            button.colors = colorBlock;
                            break;
                        }
                    }
                    index++;
                }
                catch
                {

                }
            }
            TotalScoreText.text = scoreTracker.TotalScore.ToString() + "/" + Questions.Count;
            QuestionnaireComplete = true;
            return;
        }

        UICanvas.SetActive(false);
    }

    public void IncorrectAnswer()
    {
        if (!QuestionnaireComplete)
        {
            if (!questionState.transform.gameObject.activeSelf)
            {
                questionState = GetComponentInChildren<QuestionState>();
            }

            if (!questionState.OptionSelected && questionState.transform.gameObject.activeSelf)
            {
                scoreTracker.QuestionsAnswered += 1;
                if (scoreTracker.TotalScore>0)
                scoreTracker.TotalScore--;
            }
            questionState.OptionSelected = true;
            questionState.IsAnswerCorrect = false;
        }
        else
        {
            int index = 0;

            foreach (GameObject _textMeshProUGUI in Questions)
            {
                try
                {
                    Button[] correctAns = _textMeshProUGUI.GetComponentsInChildren<Button>();
                    foreach (Button button in correctAns)
                    {
                        if (button.name.Contains("--"))
                        {
                            ColorBlock colorBlock = button.colors;
                            colorBlock.normalColor = Color.green;
                            button.colors = colorBlock;
                            break;
                        }
                    }
                    index++;
                }
                catch
                {

                }
            }
        }
    }

    public void CorrectAnswer()
    {
        if (!QuestionnaireComplete)
        {
            if (!questionState.transform.gameObject.activeSelf)
            {
                questionState = GetComponentInChildren<QuestionState>();
            }

            if (!questionState.OptionSelected && questionState.transform.gameObject.activeSelf)
            {
                scoreTracker.QuestionsAnswered++;
                scoreTracker.TotalScore++;
            }

            questionState.OptionSelected = true;
            questionState.IsAnswerCorrect = true;
        }
        else
        {
            int index = 0;

            foreach (GameObject _textMeshProUGUI in Questions)
            {
                try
                {
                    Button[] correctAns = _textMeshProUGUI.GetComponentsInChildren<Button>();
                    foreach (Button button in correctAns)
                    {
                        if (button.name.Contains("--"))
                        {
                            ColorBlock colorBlock = button.colors;
                            colorBlock.normalColor = Color.green;
                            button.colors = colorBlock;
                            break;
                        }
                    }
                    index++;
                }
                catch
                {

                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    // Start is called before the first frame update
    void Start()
    {
        GetNextQuestion();
    }

    public void OnAnswerSelected(int answerIndex) {
        Image buttonImage;
        if (answerIndex == question.GetCorrectAnswerIndex()) {
            buttonImage = answerButtons[answerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            questionText.text = "Correct!";
        } else {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            questionText.text = "Wrong Answer! The correct answer is:\n" + question.GetAnswer(correctAnswerIndex);
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }

    private void GetNextQuestion() {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }

    private void SetDefaultButtonSprite() {
        for(int i = 0; i < answerButtons.Length; i++) {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    private void DisplayQuestion() {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    private void SetButtonState(bool state) {
        for (int i = 0; i < answerButtons.Length; i++) {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}

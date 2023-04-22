using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30.0f;
    [SerializeField] float timeToShowRightAnswer = 10.0f;
    float timerValue;
    public bool isAnsweringQuestion = true;
    public bool loadNextQuestion;
    public float fillFraction;
    // Update is called once per frame
    void Start() {
        timerValue = timeToCompleteQuestion;
    }
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = 0.0f;
    }

    private void UpdateTimer() {
        timerValue -= Time.deltaTime;

        fillFraction = isAnsweringQuestion ? timerValue / timeToCompleteQuestion : timerValue / timeToShowRightAnswer;

        if (timerValue <= 0.0f) {
            if (isAnsweringQuestion) {
                timerValue = timeToShowRightAnswer;
                isAnsweringQuestion = false;
            }
            else {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }
    }
}

using System;
using UnityEngine;

/// <summary>
///     Contains one question and four answers, including the right one.
/// </summary>
[Serializable]
public struct QuestionAnswers
{
    [SerializeField]
    private string _question;

    [SerializeField]
    private string _answerA;

    [SerializeField]
    private string _answerB;

    [SerializeField]
    private string _answerC;

    [SerializeField]
    private string _answerD;

    [SerializeField]
    private Answer _correctAnswer;

    [SerializeField]
    private bool _randomize;

    private AnswerArray<string> _answers;

    public enum Answer
    {
        A,
        B,
        C,
        D
    }

    public QuestionAnswers(string question, string answerA, string answerB, string answerC, string answerD,
        Answer correctAnswer, bool randomize)
    {
        _question = question;
        _answerA = answerA;
        _answerB = answerB;
        _answerC = answerC;
        _answerD = answerD;
        _correctAnswer = correctAnswer;
        _randomize = randomize;
        _answers = new AnswerArray<string>(_answerA, _answerB, _answerC, _answerD);
    }

    public string Question
    {
        get
        {
            return _question;
        }
    }

    public Answer CorrectAnswer
    {
        get
        {
            return _correctAnswer;
        }
    }

    public bool Randomize
    {
        get
        {
            return _randomize;
        }
    }

    public AnswerArray<string> Answers
    {
        get
        {
            // If this object was created through deserialization, _answers will be null. Therefore the check.
            return _answers ?? (_answers = new AnswerArray<string>(_answerA, _answerB, _answerC, _answerD));
        }
    }
}

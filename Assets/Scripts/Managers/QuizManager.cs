using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
///     Contains all the game logic of this game.
/// </summary>
public sealed class QuizManager : MonoBehaviour
{
    private QuestionAnswers[] _questions;
    private QuestionAnswers _question;
    private int _nextQuestion;
    private AnswerArray<Button> _answerButtons;

    [Range(0, 20)]
    [SerializeField]
    private float _nextQuestionAfter;

    [SerializeField]
    private Text _questionText;

    [SerializeField]
    private Button _answerA;

    [SerializeField]
    private Button _answerB;

    [SerializeField]
    private Button _answerC;

    [SerializeField]
    private Button _answerD;

    [SerializeField]
    private Color _correctColor;

    [SerializeField]
    private Color _incorrectColor;

    [SerializeField]
    private string _finishText;

    [SerializeField]
    private Text _castText;

    private void Start()
    {
        _answerButtons = new AnswerArray<Button>(_answerA, _answerB, _answerC, _answerD);
        _nextQuestion = 0;

        var quiz = Resources.Load<Quiz>("Quizzes/Quiz");
        _questions = quiz.Randomize ? NewShuffled(quiz.Length, i => quiz[i]) : quiz.Questions;

        LoadNextQuestion();
    }

    /// <summary>
    ///     Creates a new and shuffled array from a source using the "inside-out" version of the Fisher–Yates shuffle.
    /// </summary>
    /// <typeparam name="T">The type of the objects inside the array.</typeparam>
    /// <param name="length">The length of the array.</param>
    /// <param name="get">A function which returns the element from the source.</param>
    /// <returns></returns>
    private static T[] NewShuffled<T>(int length, Func<int, T> get)
    {
        var array = new T[length];
        for (var i = 0; i < length; ++i)
        {
            var r = Random.Range(0, i + 1);
            if (i != r)
            {
                array[i] = array[r];
            }
            array[r] = get(i);
        }
        return array;
    }

    public void CheckAnswer(int answer)
    {
        foreach (var button in _answerButtons)
        {
            button.interactable = false;
        }

        _answerButtons[(int) _question.CorrectAnswer].GetComponent<Image>().color = _correctColor;

        if ((QuestionAnswers.Answer) answer != _question.CorrectAnswer)
        {
            _answerButtons[answer].GetComponent<Image>().color = _incorrectColor;
        }

        // The player needs some time to see if the answer was correct.
        Invoke("LoadNextQuestion", _nextQuestionAfter);
    }

    private void LoadNextQuestion()
    {
        if (_nextQuestion >= _questions.Length)
        {
            _questionText.text = _finishText;
            _castText.text = _questionText.text;
            foreach (var button in _answerButtons)
            {
                button.gameObject.SetActive(false);
            }
            return;
        }

        _question = _questions[_nextQuestion];

        if (_question.Randomize)
        {
            var random = NewShuffled(4, i => i);

            // The position of the correct answer has been probably changed.
            var correctAnswer = 0;
            for (var i = 0; i < random.Length; ++i)
            {
                if (_question.CorrectAnswer == (QuestionAnswers.Answer) random[i])
                {
                    correctAnswer = i;
                    break;
                }
            }

            _question = new QuestionAnswers(_question.Question, _question.Answers[random[0]],
                _question.Answers[random[1]], _question.Answers[random[2]], _question.Answers[random[3]],
                (QuestionAnswers.Answer) correctAnswer, _question.Randomize);
        }

        _questionText.text = _question.Question;
        _castText.text = _question.Question;

        for (var i = 0; i < 4; ++i)
        {
            _answerButtons[i].GetComponentInChildren<Text>().text = _question.Answers[i];
            _answerButtons[i].GetComponent<Image>().color = Color.white;
            _answerButtons[i].interactable = true;
        }

        ++_nextQuestion;
    }
}

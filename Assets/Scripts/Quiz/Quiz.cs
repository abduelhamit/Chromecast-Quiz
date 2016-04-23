using System;
using UnityEngine;

/// <summary>
///     Contains a full quiz with lots of questions and answers.
/// </summary>
[Serializable]
public sealed class Quiz : ScriptableObject
{
    [SerializeField]
    private bool _randomize;

    [SerializeField]
    private QuestionAnswers[] _questions;

    private Quiz(bool randomize, QuestionAnswers[] questions)
    {
        _randomize = randomize;
        _questions = questions;
    }

    public bool Randomize
    {
        get
        {
            return _randomize;
        }
    }

    public QuestionAnswers[] Questions
    {
        get
        {
            // It is important that the array will be cloned.
            // Otherwise, changes to the array will be applied to the asset in the project.
            return (QuestionAnswers[]) _questions.Clone();
        }
    }

    public QuestionAnswers this[int i]
    {
        get
        {
            return _questions[i];
        }
    }

    public int Length
    {
        get
        {
            return _questions.Length;
        }
    }
}

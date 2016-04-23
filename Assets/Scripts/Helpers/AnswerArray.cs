using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
///     Encapsulates any answer-related objects so you can use foreach loops and such reduce code duplications.
/// </summary>
/// <typeparam name="T">The type of the objects.</typeparam>
public sealed class AnswerArray<T> : IEnumerable<T>
{
    private readonly T[] _array;

    public AnswerArray(T a, T b, T c, T d)
    {
        _array = new[]
        {
            a, b, c, d
        };
    }

    public T this[int i]
    {
        get
        {
            return _array[i];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _array.Cast<T>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _array.GetEnumerator();
    }
}

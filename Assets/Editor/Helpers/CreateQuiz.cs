using UnityEditor;
using UnityEngine;

/// <summary>
///     Is responsible for creating quiz assets.
/// </summary>
public sealed class CreateQuiz : MonoBehaviour
{
    [MenuItem("Assets/Create/Quiz")]
    private static void CreateAsset()
    {
        var item = ScriptableObject.CreateInstance<Quiz>();
        var path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Quizzes/Quiz.asset");

        AssetDatabase.CreateAsset(item, path);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = item;
    }
}

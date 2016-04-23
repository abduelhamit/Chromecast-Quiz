using UnityEngine;

/// <summary>
///     You spin me right round, baby, right round. Like a record, baby. Right round, round, round.
/// </summary>
public sealed class RotationHelper : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotationPerSecond;

    private void Update()
    {
        transform.Rotate(_rotationPerSecond*Time.deltaTime);
    }
}

using Google.Cast.RemoteDisplay;
using UnityEngine;

/// <summary>
///     Reduces calculations on the main camera depending on the Cast status.
///     It also makes the difference between casting and not casting more visible.
/// </summary>
public sealed class CameraHelper : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public void UpdateCameraSettings()
    {
        var status = CastRemoteDisplayManager.GetInstance().IsCasting();
        _camera.clearFlags = status ? CameraClearFlags.SolidColor : CameraClearFlags.Skybox;
        _camera.cullingMask = status ? 0 : -1;
    }
}

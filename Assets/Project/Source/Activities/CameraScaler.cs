using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScaler : MonoBehaviour
{
    [SerializeField] private float targetWidth = 1080f;
    [SerializeField] private float targetHeight = 1920f;

    private void Start()
    {
        float targetAspect = targetWidth / targetHeight;
        float windowAspect = (float)Screen.width / Screen.height;

        float scale = targetAspect / windowAspect;

        Camera camera = GetComponent<Camera>();
        if (scale < 1f)
        {
            camera.orthographicSize = camera.orthographicSize / scale;
        }
    }
}

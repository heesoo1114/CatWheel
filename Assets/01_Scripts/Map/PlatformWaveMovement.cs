using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlatformWaveMovement : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private float start = 0;
    private float end = 3;

    [SerializeField] private int pointCount = 100;  // 점 개수 

    [Header("Movement")]
    [Range(-2, 2)]
    [SerializeField] private float amplitude = 1; // 진폭
    public float Amplitude => amplitude;
    [SerializeField] private float frequency = 1; // 진동수
    [SerializeField] private float moveSpeed = 3; // 속도

    private float Tau = 2 * Mathf.PI;

    private Vector3 moveVector;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointCount;
    }

    private void Update()
    {
        ActivateDraw();
    }

    // 플랫폼 생성 활성화
    private void ActivateDraw()
    {
        for (int currentPoint = 0; currentPoint < pointCount; currentPoint++)
        {
            float progress = (float)currentPoint / (pointCount - 1);
            float x = Mathf.Lerp(start, end, progress);
            float pointAmplitude = amplitude * Mathf.Lerp(0.5f, 1.5f, progress);
            float y = amplitude * Mathf.Sin((Tau * frequency * x) + (Time.time * moveSpeed));
            moveVector = new Vector3(x, y, 0);

            lineRenderer.SetPosition(currentPoint, moveVector);
        }
    }

    // 플랫폼 생성 비활성화
    private void DeactivateDraw()
    {
        lineRenderer.enabled = false;
    }

    public void SetAmplitude(float value)
    {
        amplitude = Mathf.Clamp(value, -2, 2);
    }

}

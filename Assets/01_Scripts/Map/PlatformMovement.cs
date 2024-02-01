using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlatformMovement : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private float start = 0;
    private float end = 3;

    [SerializeField] private int pointCount = 100;  // 점 개수 

    [Header("Movement")]
    [Range(-2, 2)]
    [SerializeField] private float amplitude = 1; // 진폭
    public float Amplitude
    {
        get => amplitude;
        set => amplitude = value;
    }

    [SerializeField] private Vector2 amplitudeClampValue; // 최소, 최대
    [SerializeField] private Vector2 ampitudeRandomValue; // x값에 따른 진폭 랜덤범위

    [SerializeField] private float frequency = 1; // 진동수
    [SerializeField] private float moveSpeed = 3; // 속도

    private float Tau = 2 * Mathf.PI;
    private Vector3 moveVector;

    private bool isCanDraw = true;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointCount;

        // 랜덤밸류
        ampitudeRandomValue = new Vector2(Random.Range(-10, 0), Random.Range(5, 15));
        ampitudeRandomValue *= 0.1f;

        isCanDraw = true;
    }

    private void Update()
    {
        if (isCanDraw)
        {
            Draw();
        }
    }

    public void SetAmplitude(float value)
    {
        amplitude = Mathf.Clamp(value, amplitudeClampValue.x, amplitudeClampValue.y);
    }

    // 플랫폼 생성 활성화
    private void Draw()
    {
        for (int currentPoint = 0; currentPoint < pointCount; currentPoint++)
        {
            float progress = (float)currentPoint / (pointCount - 1);
            float x = Mathf.Lerp(start, end, progress);
            float pointAmplitude = amplitude * Mathf.Lerp(ampitudeRandomValue.x, ampitudeRandomValue.y, progress);
            float y = pointAmplitude * Mathf.Sin((Tau * frequency * x) + (Time.time * moveSpeed));
            moveVector = new Vector3(x, y, 0);

            lineRenderer.SetPosition(currentPoint, moveVector);
        }
    }

    public void ActivateDraw()
    {
        lineRenderer.enabled = true;
        isCanDraw = true;
    }

    // 플랫폼 생성 비활성화
    public void DeactivateDraw()
    {
        isCanDraw = false;
        lineRenderer.enabled = false;
    }
}

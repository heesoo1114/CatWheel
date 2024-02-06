using System.Collections;
using UnityEngine;

public class NotifyComponent : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Coroutine currentCoroutine = null;

    [SerializeField] private float flashTime = 0.2f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Reset()
    {
        spriteRenderer.enabled = false;
    }

    public void PlayBlink(float endTime)
    {
        if (currentCoroutine != null)
        {
            StopBlink();
        }
        currentCoroutine = StartCoroutine(BlinkCor(endTime));
    }

    public void StopBlink()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        Reset();
    }

    private IEnumerator BlinkCor(float endTime)
    {
        float startTime = Time.timeSinceLevelLoad;
        float passedTime = 0f;
        bool isOn = false;

        while (passedTime <= endTime)
        {
            passedTime = Time.timeSinceLevelLoad - startTime;
            isOn = !isOn;
            spriteRenderer.enabled = isOn;

            yield return new WaitForSecondsRealtime(flashTime);
        }

        spriteRenderer.enabled = false;
        currentCoroutine = null;
    }
}

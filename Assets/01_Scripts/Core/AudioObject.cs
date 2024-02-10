using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioObject : PoolableMono
{
    private AudioSource audioSource;

    [SerializeField] private float pitchRandomness = 0.2f;
    private float basePitch;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClipwithVariablePitch(AudioClip clip)
    {
        StartCoroutine(PlayClipwithVariablePitchCor(clip));
    }

    public void PlayClip(AudioClip clip)
    {
        StartCoroutine(PlayClipCor(clip));
    }

    private IEnumerator PlayClipwithVariablePitchCor(AudioClip clip)
    {
        float randomPitcch = Random.Range(-pitchRandomness, +pitchRandomness);
        audioSource.pitch = basePitch + randomPitcch;
        PlayClip(clip);
        yield return null;
    }

    private IEnumerator PlayClipCor(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
        PoolManager.Instance.Push(this);
    }

    public override void OnPop()
    {
        basePitch = pitchRandomness;
    }

    public override void OnPush()
    {

    }
}
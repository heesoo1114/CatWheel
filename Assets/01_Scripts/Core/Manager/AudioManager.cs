using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    // ���� �ʼ�
    private bool isMuted = false;
    public bool IsMuted => isMuted;

    private PlayerData playerData;

    public override void Init()
    {
        playerData = GameManager.Instance.PlayerData;
        isMuted = playerData.isMuted;

        if (isMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    public void Play(AudioClip clip, bool isWithVariablePitch = false)
    {
        AudioObject audioObj = PoolManager.Instance.Pop("AudioObject") as AudioObject;
        if (isWithVariablePitch)
        {
            audioObj.PlayClipwithVariablePitch(clip);
        }
        else
        {
            audioObj.PlayClip(clip);
        }
    }

    public void VolumeChange()
    {
        if (isMuted)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
        isMuted = !isMuted;
    }
}

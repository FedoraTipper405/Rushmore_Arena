using UnityEngine;

public enum SoundClip
{
    Shoot
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _soundClip;
    [SerializeField]
    private AudioSource SFXSource;
    [SerializeField]
    private static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static void PlaySound(SoundClip soundClip)
    {
        instance.SFXSource.PlayOneShot(instance._soundClip[(int)soundClip]);
    }
}

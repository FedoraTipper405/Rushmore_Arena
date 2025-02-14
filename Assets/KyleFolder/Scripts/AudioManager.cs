using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioList;
    [SerializeField]
    private AudioSource SFXSource;
    [SerializeField]
    private AudioSource MusicSource;
    [SerializeField]
    public static AudioManager Instance;
    [SerializeField]
    public SOVolumeSettings volumeSettings;

    public void Start()
    {
        SFXSource.volume = volumeSettings.playerVolume;
        MusicSource.volume = volumeSettings.backgroundVolume;
    }
    public void Awake()
    {
        Instance = this;
    }

    public static void PlaySound(int sound)
    {
        Instance.SFXSource.PlayOneShot(Instance.audioList[sound]);
    }
}

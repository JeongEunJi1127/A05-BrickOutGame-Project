using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;
    [SerializeField] private AudioClip backGroundAudio;
    [SerializeField] private AudioClip btnClickAudio;
    [SerializeField] private AudioClip brickAudio;
    [SerializeField] private AudioClip GameClearAudio;
    [SerializeField] private AudioClip GameOverAudio;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBackGroundAudio();
    }

    public void PlayBackGroundAudio()
    {
        audioSource.clip = backGroundAudio;
        audioSource.Play();
    }

    public void BtnClickAudio()
    {
        audioSource.PlayOneShot(btnClickAudio);
    }

    public void ClearAudio()
    {
        audioSource.ignoreListenerPause = true;
        audioSource.clip = GameClearAudio;
        audioSource.Play();
    }

    public void OverAudio()
    {
        audioSource.ignoreListenerPause = true;
        audioSource.clip = GameOverAudio;
        audioSource.Play();
    }

    public void BallCollisionAudio()
    {
        audioSource.PlayOneShot(brickAudio);
    }
}

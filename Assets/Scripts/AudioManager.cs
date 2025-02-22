using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("---- Audio Source ----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----- Audio Clip ----")]
    public AudioClip bgm;
    public AudioClip pickup;
    public AudioClip rescue;
    public AudioClip gameOver;
    public AudioClip victory;

    // Start is called before the first frame update
    private void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

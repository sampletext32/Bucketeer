using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip fxSoundGood;

    [SerializeField]
    private AudioClip fxSoundWrong;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayFxGood()
    {
        _audioSource.PlayOneShot(fxSoundGood);
    }

    public void PlayFxWrong()
    {
        _audioSource.PlayOneShot(fxSoundWrong);
    }
}

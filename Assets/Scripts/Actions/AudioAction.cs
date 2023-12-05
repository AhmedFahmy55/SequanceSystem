using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAction : SequanceAction
{

    [SerializeField] private AudioClip audioClip;
    [SerializeField] private bool shouldW8ToFinish;


    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Excute()
    {
        //skip event if there is no audioSource
        if (_audioSource == null)
        {
            OnComplete?.Invoke();
            return;
        }
        _audioSource.PlayOneShot(audioClip);

        if(shouldW8ToFinish)
        {
            StartCoroutine(WaitAudio());
        }
        else 
        { 
            OnComplete?.Invoke();
        }
    }

    private IEnumerator WaitAudio()
    {
        while (_audioSource.isPlaying)
        {
            yield return null;
        }
        OnComplete?.Invoke();
    }
}

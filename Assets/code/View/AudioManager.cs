using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour {

    public  AudioSource audioSource;
    public AudioClip guideAudio;
    private void Awake()
    {

        
        new GamePhaseListener(typeof(EnterPPTScenePhase), TriggerTime.START, () =>
        {
            audioSource.PlayOneShot(guideAudio);
        });
         new GamePhaseListener(typeof(ExitPPTScenePhase), TriggerTime.START, () =>
        {
            audioSource.Stop();
        });
    
    }
   
}





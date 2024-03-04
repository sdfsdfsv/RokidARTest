using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour {

    public AudioSource startAudioSource;
    public AudioClip startAudio;
    public AudioSource guideAudioSource;
    public AudioClip guideAudio;
    private void Awake()
    {
        
        new GamePhaseListener(typeof(GameStartPhase), TriggerTime.START, () =>
        {
          
            startAudioSource.PlayOneShot(startAudio);
        });

        new GamePhaseListener(typeof(EnterPPTScenePhase), TriggerTime.AT, () =>
        {
            startAudioSource.Stop();
            guideAudioSource.PlayOneShot(guideAudio);
        });
         new GamePhaseListener(typeof(ExitPPTScenePhase), TriggerTime.START, () =>
        {
            guideAudioSource.Stop();
        });
    
    }
   
}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour {
    [Space(10)]
    public GameObject testObject;

    public GameObject guide;

    private void Start() {

        GamePhaseManager.getInstance().StartGame();
        new GamePhaseListener(typeof(EnterPPTScenePhase), TriggerTime.START, () =>
        {
            
            guide.SetActive(true);
           
        });
      

    }
    
}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour {
    [Space(10)]
    public GameObject testObject;

    private void Start() {
        GamePhaseManager.getInstance().StartGame();

        new GamePhaseListener(typeof(EnterTestingScenePhase), TriggerTime.END, () =>
        {
            testObject.SetActive(true);
        });
         new GamePhaseListener(typeof(ExitTestingScenePhase), TriggerTime.END, () =>
        {
            testObject.SetActive(false);
        });

    }
    
}





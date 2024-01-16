using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LogManager : MonoBehaviour {
    
    private void Awake() {
        new GamePhaseListener(typeof(GameStartPhase), TriggerTime.START, () => {
            Debug.Log("game started");
        });
        new GamePhaseListener(typeof(GameEndPhase), TriggerTime.START, () => {
            Debug.Log("game ended");
        });
    }
}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour {
    private void Start() {
        GamePhaseManager.getInstance().StartGame();
    }
    
}





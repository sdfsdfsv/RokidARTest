using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UIManager : MonoBehaviour
{

    private void Awake() {
        
   
        new GamePhaseListener(typeof(GameStartPhase), TriggerTime.START, () =>
        {
            GameObject prefabToInstantiate = Resources.Load("MainUI") as GameObject;

            if (prefabToInstantiate != null)
            {
                // Scene scene = SceneManager.GetActiveScene ();
                Instantiate(prefabToInstantiate);
            }
            else
            {
                Debug.LogError("Prefab not found in Resources folder.");
            }
        });
    }


}





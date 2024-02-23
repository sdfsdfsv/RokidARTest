using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Rokid.UXR.Interaction;


public class InputManager : MonoBehaviour {
    
    
    private void Awake()
    {
        
    }

    private GestureType currentGestureType;

    private void Update() {

        if(GesEventInput.Instance.GetGestureType(HandType.LeftHand) == currentGestureType)
            return;
        currentGestureType = GesEventInput.Instance.GetGestureType(HandType.LeftHand);
        
        if (currentGestureType == GestureType.Pinch){
            GamePhaseManager.getInstance().pushPhase(new HandPinchPhase());
        }
        else if (currentGestureType == GestureType.OpenPinch){
            GamePhaseManager.getInstance().pushPhase(new HandOpenPinchPhase());
        }
        else if (currentGestureType == GestureType.Grip){
            GamePhaseManager.getInstance().pushPhase(new HandGripPhase());
        }
        
        
    }
}





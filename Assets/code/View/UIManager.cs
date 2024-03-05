using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using Rokid.UXR.Interaction;
using TMPro;
using System.Data.Common;


public class UIManager : MonoBehaviour
{

    public GameObject startUI;
    public UIElement startButton;



    
    private void Awake()
    {


        new GamePhaseListener(typeof(GameStartPhase), TriggerTime.START, () =>
        {
            startUI.gameObject.SetActive(true);
            startButton.SetOnClickHandler(() =>
            {
                startUI.gameObject.SetActive(false);
                GamePhaseManager.getInstance().appendPhase(new EnterPPTScenePhase());   
                
            });

           
        });

       

    
    }

}





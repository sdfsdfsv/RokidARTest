using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Rokid.UXR.Interaction;


public class UIManager : MonoBehaviour
{

    public UIElement startButton;

    public UIElement endButton;

    public GameObject mainUI;

    public Text handGestureDebugText;
    public Image leftHanddDebugImage;
    public Image rightHanddDebugImage;

    public Sprite openPinchImage;

    public Sprite pinchImage;

    public Sprite palmImage;

    public Sprite gripImage;

    public Sprite noneImage;

    private void Awake()
    {


        new GamePhaseListener(typeof(GameStartPhase), TriggerTime.START, () =>
        {
            startButton.gameObject.SetActive(true);
            endButton.gameObject.SetActive(true);
            startButton.SetOnClickHandler(() =>
            {
                GamePhaseManager.getInstance().appendPhase(new EnterMainScenePhase());
            });

            endButton.SetOnClickHandler(() =>
            {
                GamePhaseManager.getInstance().EndGame();
            });
        });


        new GamePhaseListener(typeof(EnterMainScenePhase), TriggerTime.START, () =>
        {
            startButton.gameObject.SetActive(false);
            endButton.gameObject.SetActive(false);
            mainUI.SetActive(true);
            handGestureDebugText.gameObject.AddComponent<UpdateListener>().SetUpdateHandler(() =>
            {
                String displayText = "";
                displayText += "lefthand左手手势: " + GesEventInput.Instance.GetGestureType(HandType.LeftHand).ToString();
                displayText += "\n";
                displayText += "righthand右手: " + GesEventInput.Instance.GetGestureType(HandType.RightHand).ToString();
                displayText += "\n\n";
                displayText += "lefthand左手掌心: " + GesEventInput.Instance.GetHandOrientation(HandType.LeftHand).ToString();
                displayText += "\n";
                displayText += "righthand右手: " + GesEventInput.Instance.GetHandOrientation(HandType.RightHand).ToString();
                handGestureDebugText.text = displayText;
            });

            leftHanddDebugImage.gameObject.AddComponent<UpdateListener>().SetUpdateHandler(() =>
            {
                
                leftHanddDebugImage.GetComponent<Image>().sprite = getHandSprite(GesEventInput.Instance.GetGestureType(HandType.LeftHand));
            });
            rightHanddDebugImage.gameObject.AddComponent<UpdateListener>().SetUpdateHandler(() =>
            {
                rightHanddDebugImage.GetComponent<Image>().sprite = getHandSprite(GesEventInput.Instance.GetGestureType(HandType.RightHand));
            });
        });
    }

    private Sprite getHandSprite(GestureType gestureType)
    {
        if (gestureType == GestureType.Grip)
        {
            return gripImage;
        }
        else if (gestureType == GestureType.Palm)
        {
            return palmImage;
        }
        else if (gestureType == GestureType.OpenPinch)
        {
            return openPinchImage;
        }
        else if (gestureType == GestureType.Pinch)
        {
            return pinchImage;
        }
        

        return noneImage;
    }


}





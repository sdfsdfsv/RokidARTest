using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using Rokid.UXR.Interaction;
using Aspose.Slides;


public class UIManager : MonoBehaviour
{

    public UIElement startButton;

    public UIElement endButton;

    [Space(10)]
    public GameObject mainUI;

    public Text handGestureDebugText;
    public Image leftHanddDebugImage;
    public Image rightHanddDebugImage;

    public Sprite openPinchImage;

    public Sprite pinchImage;

    public Sprite palmImage;

    public Sprite gripImage;

    public Sprite noneImage;

    public UIElement importBtn;
    public UIElement testBtn;
    public UIElement settingsBtn;
    public UIElement playBtn;

    public GridLayoutGroup pptGridLayoutGroup;

    [Space(10)]

    public GameObject testingUI;
    public UIElement testingExitBtn;

    [Space(10)]

    public GameObject settingUI;
    public UIElement settingExitBtn;

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
            ImportTest importTest = new ImportTest();

            importBtn.SetOnClickHandler(() =>
            {
                GamePhaseManager.getInstance().appendPhase(new ImportPPTPhase());
            });

            testBtn.SetOnClickHandler(() =>
            {
                GamePhaseManager.getInstance().appendPhase(new ExitMainScenePhase());
                GamePhaseManager.getInstance().appendPhase(new EnterTestingScenePhase());

            });

            settingsBtn.SetOnClickHandler(() =>
            {
                GamePhaseManager.getInstance().appendPhase(new ExitMainScenePhase());
                GamePhaseManager.getInstance().appendPhase(new EnterSettingUIPhase());
            });
        });

        new GamePhaseListener(typeof(ExitMainScenePhase), TriggerTime.START, () =>
        {
            mainUI.SetActive(false);
        });


        new GamePhaseListener(typeof(ImportPPTPhase), TriggerTime.START, () =>
        {

        });
        new GamePhaseListener(typeof(ImportPPTPhase), TriggerTime.END, () =>
        {

            GameObject pptCover = new GameObject("ppt");
            Presentation pre = ((ImportPPTPhase)Phase.getCurrentPhase()).getPresentation();
            Sprite cover = PPTCtrl.getPPTPage(pre, 0);
            String pptName = Path.GetFileName(((ImportPPTPhase)Phase.getCurrentPhase()).getPPTPath());
            pptCover.name = pptName;
            pptCover.AddComponent<UIElement>().setTargetGraphic(cover);
            pptCover.transform.SetParent(pptGridLayoutGroup.transform);

        });


        new GamePhaseListener(typeof(EnterTestingScenePhase), TriggerTime.END, () =>
        {
            testingUI.SetActive(true);

            testingExitBtn.SetOnClickHandler(() =>
            {
                GamePhaseManager.getInstance().appendPhase(new ExitTestingScenePhase());
                GamePhaseManager.getInstance().appendPhase(new EnterMainScenePhase());
            });
        });

        new GamePhaseListener(typeof(ExitTestingScenePhase), TriggerTime.START, () =>
        {
            testingUI.SetActive(false);

        });


        new GamePhaseListener(typeof(EnterSettingUIPhase), TriggerTime.END, () =>
        {
            settingUI.SetActive(true);
            settingExitBtn.SetOnClickHandler(() =>
            {
                GamePhaseManager.getInstance().appendPhase(new ExitSettingScenePhase());
                GamePhaseManager.getInstance().appendPhase(new EnterMainScenePhase());
            });

        });

        new GamePhaseListener(typeof(ExitSettingScenePhase), TriggerTime.START, () =>
        {
            settingUI.SetActive(false);
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





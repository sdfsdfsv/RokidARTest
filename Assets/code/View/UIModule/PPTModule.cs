using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
public class PPTModule : MonoBehaviour
{

    private bool startPPTPlaying = false;

    public List<GameObject> presentation;

    private GameObject currentPresentation = null;

    private void Awake()
    {

        GamePhaseListener gamePhaseListener = new GamePhaseListener(typeof(EnterPPTScenePhase), TriggerTime.START, () =>
        {
            if (presentation.Count == 0) return;
            currentPresentation = presentation[0];
            startPPTPlaying = true;
            GamePhaseManager.getInstance().appendPhase(new PlayPPTPhase(currentPresentation));
        });



        new GamePhaseListener(typeof(ExitPPTScenePhase), TriggerTime.START, () =>
        {
            startPPTPlaying = false;
            foreach (var pre in presentation)
            {
                pre.gameObject.SetActive(false);
            }
            GamePhaseManager.getInstance().appendPhase(new GameStartPhase());

        });

        new GamePhaseListener(typeof(PlayPPTPhase), TriggerTime.START, () =>
        {
            currentPresentation.SetActive(true);
        });

        new GamePhaseListener(typeof(HandPinchPhase), TriggerTime.START, () =>
        {
            if (!startPPTPlaying) return;

            currentPresentation.gameObject.SetActive(false);

            try
            {
                currentPresentation = presentation[presentation.IndexOf(currentPresentation) + 1];
                GamePhaseManager.getInstance().appendPhase(new PlayPPTPhase(currentPresentation)); ;
            }
            catch (Exception)
            {

                GamePhaseManager.getInstance().appendPhase(new ExitPPTScenePhase());
            }

        });
    }
}
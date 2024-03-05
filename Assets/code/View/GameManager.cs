using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    [Space(10)]
    public GameObject testObject;

    public GameObject guide;

    private void Start()
    {

        GamePhaseManager.getInstance().StartGame();
        new GamePhaseListener(typeof(EnterPPTScenePhase), TriggerTime.START, () =>
        {

            guide.SetActive(true);
            StartCoroutine(playGuideAnimation());


        });

        new GamePhaseListener(typeof(PlayPPTPhase), TriggerTime.START, () =>
        {
            StartCoroutine(playGuideAnimation());

        });

    }

    IEnumerator playGuideAnimation()
    {
        bool loop = true;
        while (loop)
        {

            guide.GetComponent<Animator>().Play("Idle");
            new GamePhaseListener(typeof(ExitPPTScenePhase), TriggerTime.START, () =>
            {
                loop = false;
            });

            yield return new WaitForSeconds(3f);

        }
        yield break;
    }

}





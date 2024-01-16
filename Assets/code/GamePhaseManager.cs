using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;


public class GamePhaseManager : MonoBehaviour
{

    private static GamePhaseManager instance;
    private List<Phase> phases = new List<Phase>();
    private Mutex phasesMutex = new Mutex();
    private Semaphore phasesSemaphore = new Semaphore(0, 1000);
    private int currentPhaseInd = 0;

    public static GamePhaseManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameObject("GamePhaseManager").AddComponent<GamePhaseManager>();   
        }
        return instance;
    }

    public GamePhaseManager()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(procGamePhases());
        
        appendPhase(new GameStartPhase());
    }

    IEnumerator procGamePhases()
    {
        while (true)
        {

            if(currentPhaseInd<phases.Count){
                execPhase(phases[currentPhaseInd]);
                currentPhaseInd++;
            }
            yield return new WaitForSeconds(0.01f);

        }
    }

    public void execPhase(Phase phase)
    {
        phase.Start();
        phase.Exec();
        phase.End();
    }
    public void pushPhase(Phase phase)
    {
        execPhase(phase);
    }

    public void appendPhase(Phase phase)
    {
        phases.Add(phase);
    }

    public Phase getCurrentPhase()
    {
        if (currentPhaseInd >= phases.Count) { phasesMutex.ReleaseMutex(); return null; }
        return phases[currentPhaseInd];
    }
    public void EndGame()
    {
        pushPhase(new GameEndPhase());
    }

}


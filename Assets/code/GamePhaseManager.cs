using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;


public class GamePhaseManager
{

    private static GamePhaseManager instance;
    private Thread gamePhaseProccessingThread;



    private List<Phase> phases = new List<Phase>();
    private Mutex phasesMutex = new Mutex();
    private Semaphore phasesSemaphore = new Semaphore(0, 1000);
    private int currentPhaseInd = 0;

    public static GamePhaseManager getInstance()
    {
        if (instance == null)
        {
            instance = new GamePhaseManager();
        }
        return instance;
    }

    public GamePhaseManager()
    {
        gamePhaseProccessingThread = new Thread(procGamePhases);
        gamePhaseProccessingThread.Start();
       

    }

    public void StartGame(){
        pushPhase(new GameStartPhase());
    }

    private void procGamePhases()
    {
        while (true)
        {

            phasesSemaphore.WaitOne();
            phasesMutex.WaitOne();
            execPhase(phases[currentPhaseInd]);
            phasesMutex.ReleaseMutex();
            currentPhaseInd++;

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
        phasesMutex.WaitOne();
        phases.Add(phase);
        phasesMutex.ReleaseMutex();
        phasesSemaphore.Release();
    }

    public Phase getCurrentPhase()
    {
        phasesMutex.WaitOne();
        if (currentPhaseInd >= phases.Count) { phasesMutex.ReleaseMutex(); return null; }
        phasesMutex.ReleaseMutex();
        return phases[currentPhaseInd];
    }
    public void EndGame(){
        pushPhase(new GameEndPhase());
    }

}


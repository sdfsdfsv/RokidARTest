using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GamePhaseListener  {
    

    private static List<GamePhaseListener> gamePhaseListeners = new List<GamePhaseListener>();

    // the type of phase that triggers the game event
    private Type triggeredPhaseType;
    // the time of phase that causes the game event
    private TriggerTime triggeredTime;

    private Action action;


    public static List<GamePhaseListener> getGamePhaseListeners(){
        return gamePhaseListeners;
    } 

    public GamePhaseListener(Type triggeredPhaseType, TriggerTime triggeredTime, Action action)
    {
        this.triggeredPhaseType = triggeredPhaseType;
        this.triggeredTime = triggeredTime;
        this.action = action;
        gamePhaseListeners.Add(this);
    }

    public Type getTriggeredPhaseType(){
        return triggeredPhaseType;
    }

    public TriggerTime getTriggeredTime(){
        return triggeredTime;
    }

    public Action getAction(){
        return action;
    }


   
}
public enum TriggerTime{
    START,AT,END,
}




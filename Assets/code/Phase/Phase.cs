using System.Collections;
using UnityEngine;
using System;
using System.Threading;
using System.Collections.Generic;

public class Phase
{
    private static Phase prevPhase;
    private static Phase currentPhase;

    public virtual void Start()
    {
        prevPhase = currentPhase;
        Debug.Log("Start Phase: " + this.GetType().Name);
        currentPhase = this;
        triggerListeners(TriggerTime.START);
    }
    public virtual void Exec()
    {
        triggerListeners(TriggerTime.AT);
    }

    public virtual void End()
    {
        triggerListeners(TriggerTime.END);
        currentPhase = prevPhase;
    }

    // return the process of this phase from 0 to 1
    private void triggerListeners(TriggerTime triggerTime)
    {
        List<GamePhaseListener> listeners = GamePhaseListener.getGamePhaseListeners();
        for (int i = listeners.Count - 1; i >= 0; i--)
{
            var listener = listeners[i];
            // Your conditions and invocation.
            if (listener.getTriggeredPhaseType() != this.GetType()) continue;
            if (listener.getTriggeredTime() != triggerTime) continue;
            listener.setTriggeredPhase(this);
            listener.getAction().Invoke();
        }
    }

    public static Phase getCurrentPhase()
    {
        return currentPhase;
    }


}

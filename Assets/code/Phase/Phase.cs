using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

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
        GamePhaseListener.getGamePhaseListeners().ForEach(listener =>
        {
          
            if (listener.getTriggeredPhaseType() != this.GetType()) return;
            if (listener.getTriggeredTime() != triggerTime) return;
            listener.setTriggeredPhase(this);
            listener.getAction().Invoke();
        });
    }

    public static Phase getCurrentPhase()
    {
        return currentPhase;
    }


}

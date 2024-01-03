using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Phase
{

    public virtual void Start()
    {
        Debug.Log("Start Phase: " + this.GetType().Name);
        triggerListeners(TriggerTime.START);
    }
    public virtual void Exec()
    {
        triggerListeners(TriggerTime.AT);

    }

    public virtual void End()
    {
        triggerListeners(TriggerTime.END);
    }

    // return the process of this phase from 0 to 1
    private void triggerListeners(TriggerTime triggerTime)
    {
        GamePhaseListener.getGamePhaseListeners().ForEach(listener =>
        {
            if (listener.getTriggeredPhaseType() != this.GetType()) return;
            if (listener.getTriggeredTime() != triggerTime) return;
            listener.getAction().Invoke();
        });
    }


}

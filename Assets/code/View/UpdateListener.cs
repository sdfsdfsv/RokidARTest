using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateListener : MonoBehaviour{

    private Action updateHandler;
    public void SetUpdateHandler(Action update)
    {
        updateHandler = update;
    }
    private void Update()
    {
        if (updateHandler == null) return;
        updateHandler.Invoke();
    }

    
}
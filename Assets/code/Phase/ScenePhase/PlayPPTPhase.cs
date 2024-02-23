using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using Aspose.Slides;
// using UnityEngine.SceneManagement;

public class PlayPPTPhase : Phase
{
    private GameObject presentation;

    public PlayPPTPhase(GameObject presentation)
    {
        this.presentation = presentation;
    }

    public override void Exec()
    {
        base.Exec();
    }

    public GameObject getPresentation()
    {
        return presentation;
    }
    
    public void setPresentation(GameObject presentation)
    {
        this.presentation = presentation;
    }

}

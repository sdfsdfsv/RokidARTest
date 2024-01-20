using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using Aspose.Slides;
// using UnityEngine.SceneManagement;

public class EnterPlayingScenePhase : Phase
{
    private Presentation presentation;

    public EnterPlayingScenePhase(Presentation presentation)
    {
        this.presentation = presentation;
    }

    public Presentation getPresentation()
    {
        return presentation;
    }
    
    public void setPresentation(Presentation presentation)
    {
        this.presentation = presentation;
    }

}

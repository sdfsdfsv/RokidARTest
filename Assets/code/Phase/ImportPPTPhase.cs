using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using Aspose.Slides;
// using UnityEngine.SceneManagement;

public class ImportPPTPhase : Phase
{
    private string pptPath;

    private Presentation presentation;

    public override void Exec()
    {
        pptPath = ImportTest.ImportFile();
        if (pptPath == null)
            return;

        presentation = new Presentation(pptPath);
    }

    public string getPPTPath()
    {
        return pptPath;
    }
    public Presentation getPresentation()
    {
        return presentation;
    }

    public void setPPTPath(string pptPath)
    {
        this.pptPath = pptPath;
    }

    public void setPresentation(Presentation presentation)
    {
        this.presentation = presentation;
    }
}

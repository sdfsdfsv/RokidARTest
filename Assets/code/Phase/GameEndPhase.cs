using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
// using UnityEngine.SceneManagement;

public class GameEndPhase : Phase
{
    public override void Exec()
    {
       base.Exec();
       Application.Quit();

    }
}

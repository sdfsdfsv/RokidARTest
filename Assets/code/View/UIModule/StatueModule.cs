using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueModule : UIFaceCam
{
    // Start is called before the first frame update
    public override void Start()
    {   
        base.Start();
        pos = transform.position;
    }
   
    Vector3 pos;
    public float speed;
    public float scale;

    // Update is called once per frame
    public override void LateUpdate()
    {   
        base.LateUpdate();
        float rotateFactor = (float)(Math.Sin(Time.time*speed)*scale);
        transform.RotateAround(pos, transform.up, rotateFactor);


    }
}

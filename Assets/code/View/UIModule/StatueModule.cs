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
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        pos = meshRenderer.bounds.center;
        
    }
   
    Vector3 pos;
    public float speed;
    public float scale;

    // Update is called once per frame
    public void Update()
    {   
        
        float rotateFactor = Math.Sign(Math.Sin(Time.time*speed))*scale/100;
        transform.RotateAround(pos, Vector3.up, rotateFactor);


    }
}

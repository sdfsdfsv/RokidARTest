using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCam: MonoBehaviour{

    Vector3 screenPos;
    public virtual  void Start() {
        
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.x = Mathf.Max(screenPos.x,20);
        screenPos.y = Mathf.Max(screenPos.y,20);
    }
    public virtual void LateUpdate() {
        
        transform.LookAt(
            transform.position - Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up
        );
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
        
        
    }
}
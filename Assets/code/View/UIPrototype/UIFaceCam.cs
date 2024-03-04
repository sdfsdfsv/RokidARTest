using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCam: MonoBehaviour{
    
    Quaternion rotation;
    Vector3 screenPos;
    
    public virtual  void Start() {
        
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        rotation = Camera.main.transform.rotation;
    }
    void LateUpdate() {
        
        transform.LookAt(Camera.main.transform);
        transform.rotation*= rotation;
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
        
        
    }
}
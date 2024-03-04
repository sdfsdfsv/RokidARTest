using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
[RequireComponent(typeof(RectTransform))]
public class UIStaring : MonoBehaviour
{

    AnimationCurve animationCurve = AnimationCurve.EaseInOut(0,0,1,1);

    Vector3 scale;

    public float effectMultiplier=1f;
    private void Awake() {
        scale = GetComponent<RectTransform>().localScale;
    }

    float scaleFactor=0f;
    private void Update() {
        
        if(Vector3.Angle(Camera.main.transform.forward, GetComponent<RectTransform>().position - Camera.main.transform.position)<5f){
            scaleFactor = Mathf.Min(scaleFactor+Time.deltaTime*effectMultiplier ,1f);
        }
        else{
            scaleFactor = Mathf.Max(scaleFactor-Time.deltaTime*effectMultiplier ,0f);
        }
        GetComponent<RectTransform>().localScale = scale*(1f+0.2f*animationCurve.Evaluate(scaleFactor));
    }


}

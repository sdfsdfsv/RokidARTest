using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
[RequireComponent(typeof(RectTransform))]

public class UIMotion : MonoBehaviour
{

    Vector3 position;

    public AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public enum MotionAxis
    {
        Right,
        Left,
        Up,
        Down

    }

    public MotionAxis motionAxis;

    [Range(0, 1)]
    public float speed = 0.1f;

    private void Awake()
    {
        position = GetComponent<RectTransform>().localPosition;

    }


    protected virtual void OnEnable()
    {
        StartCoroutine(enterEffect());
    }
    protected virtual void OnDisable()
    {
    }

    IEnumerator enterEffect()
    {
        Vector3 startPos = position;
        if (motionAxis == MotionAxis.Right)
        {
            startPos += Vector3.right * 333;

        }
        else if (motionAxis == MotionAxis.Left)
        {
            startPos -= Vector3.right * 333;

        }
        else if (motionAxis == MotionAxis.Up)
        {
            startPos += Vector3.up * 333;
        }
        else
        {
            startPos -= Vector3.up * 333;
        }
        GetComponent<RectTransform>().localPosition = startPos;
        Vector3 offset = position - startPos;
        Vector3 dir = offset.normalized;

        float time = Time.time;
        while (true)
        {
            
            Vector3 pos = startPos + animationCurve.Evaluate((Time.time-time) * speed) * offset;
            if (Vector3.Dot(pos - position, dir) > 0)
            {
                GetComponent<RectTransform>().localPosition = position;
                yield break;
            }
            GetComponent<RectTransform>().localPosition = pos;

            yield return null;

        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class UIRectShader : MonoBehaviour
{

    public Material effectMaterial;

    private void Awake()
    {

        // 动态创建对象时为每个对象创建新的材质实例
        newMaterialInstance = Instantiate(effectMaterial);

        gameObject.GetComponent<Image>().material = newMaterialInstance;

    }
    Material newMaterialInstance;
    private void Update()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Rect rect = rectTransform.rect;
        // Adjust UVRect based on the local position
        Vector4 UVRect = new Vector4(transform.localPosition.x, transform.localPosition.y, transform.localPosition.x + rect.width, transform.localPosition.y + rect.height);

        newMaterialInstance.SetVector("_UVRect", UVRect);
    }

}





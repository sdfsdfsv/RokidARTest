using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class UIElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool interactable = true;
    private Sprite targetGraphic;
    public Color normalColor = Color.white;
    public Color highlightColor = new Color(.93f, .93f, .93f);
    public Color pressedColor = Color.grey * 1.2f;
    public Color selectedColor = new Color(.93f, .93f, .93f);
    public Color disabledColor = Color.grey * 1.3f;
    public float colorMultiplier = 1.0f;

    public bool motionEffect = true;
    private float zOffset = 0.0f;

    public float effectMultiplier = 1.0f;

    private void Awake()
    {

        setTargetGraphic(targetGraphic);

    }
    private void Update() {
        if(motionEffect == false)return;

        Vector3 pos = this.gameObject.GetComponent<RectTransform>().localPosition;
        int dir = Math.Sign(zOffset-this.gameObject.GetComponent<RectTransform>().localPosition.z);
        float moveDisUsingSmoothStep = Mathf.SmoothStep(this.gameObject.GetComponent<RectTransform>().localPosition.z, zOffset, Time.deltaTime * 10*effectMultiplier)-this.gameObject.GetComponent<RectTransform>().localPosition.z;
        moveDisUsingSmoothStep*=dir;
        float moveDis =  Mathf.Max(moveDisUsingSmoothStep,.6f);
        float zPos = this.gameObject.GetComponent<RectTransform>().localPosition.z+moveDis*dir;
        if(zPos*dir>zOffset*dir){
            zPos = zOffset;
        }
        this.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y, zPos);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!interactable) return;
        zOffset = -20f*effectMultiplier;
        GetComponent<Image>().color = highlightColor * colorMultiplier;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!interactable) return;
        zOffset = 0f;
        GetComponent<Image>().color = normalColor * colorMultiplier;
    }
    // public virtual void  
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!interactable) return;
        zOffset = 40f*effectMultiplier;
        //按下
        GetComponent<Image>().color = pressedColor * colorMultiplier;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!interactable) return;
        OnClick();
        zOffset = -20f*effectMultiplier;
        //抬起
        GetComponent<Image>().color = normalColor * colorMultiplier;
    }


    protected virtual void OnEnable()
    {
        GetComponent<Image>().color = normalColor * colorMultiplier;
    }
    protected virtual void OnDisable()
    {
        GetComponent<Image>().color = disabledColor * colorMultiplier;
    }

    private Action onClickHandler;

    public void SetOnClickHandler(Action onClick)
    {
        onClickHandler = onClick;
    }

    [ContextMenu("OnClick")]
    public virtual void OnClick()
    {
        // 检查是否有设置点击处理程序
        if (onClickHandler == null) return;

        onClickHandler.Invoke();

    }


    public void setInteractable(bool interactable)
    {
        this.interactable = interactable;
        if (interactable)
            GetComponent<Image>().color = normalColor * colorMultiplier;
        else
            GetComponent<Image>().color = disabledColor * colorMultiplier;

    }
    public void setTargetGraphic(Sprite targetGraphic)
    {
        this.targetGraphic = targetGraphic;

        if (GetComponent<Image>() == null)
        {
            gameObject.AddComponent<Image>();
        }

        if (targetGraphic == null) return;
        // 设置图片
        GetComponent<Image>().sprite = targetGraphic;

    }


}

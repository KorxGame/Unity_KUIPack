using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KToggle_Shadow : Toggle
{
    //private Animator animator;
    private Vector2 initialPos = Vector2.zero;
    private float hoverScale = 3f / 4f;
    private float hoverDur = 0.2f;
    private float pressDur = 0.2f;

    private bool isDown = false;

    void Start()
    {
        initialPos = targetGraphic.rectTransform.anchoredPosition;
        
        GetComponent<Toggle>().onValueChanged.AddListener(ison => { DoAnim(ison); });
    }


    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if (!isDown)
            targetGraphic.rectTransform.DoMoveTarget(initialPos * (isOn ? 1 - hoverScale : hoverScale), hoverDur);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        if (!isDown)
            targetGraphic.rectTransform.DoMoveTarget(initialPos * (isOn ? 0 : 1), hoverDur);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        isDown = true;
        targetGraphic.rectTransform.DoMoveTarget(Vector2.zero, pressDur);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        isDown = false;
        if (!isOn)
            targetGraphic.rectTransform.DoMoveTarget(initialPos, pressDur);
    }


    // public override void OnPointerClick(PointerEventData eventData)
    // {
    //     base.OnPointerClick(eventData);
    //     targetGraphic.rectTransform.DoMoveTarget(isOn ? Vector2.zero : initialPos, pressDur);
    // }
    
    void DoAnim(bool _ison)
    {
        targetGraphic.rectTransform.DoMoveTarget(isOn ? Vector2.zero : initialPos, pressDur);
    }
  
}
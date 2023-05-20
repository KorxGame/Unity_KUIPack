using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KButton_Shadow : Button
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
    }


    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if (!isDown)
            targetGraphic.rectTransform.DoMoveTarget( initialPos * hoverScale, hoverDur);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        if (!isDown)
            targetGraphic.rectTransform.DoMoveTarget(initialPos, hoverDur);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        isDown = true;
        targetGraphic.rectTransform.DoMoveTarget( Vector2.zero, pressDur);

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        isDown = false;
        
        targetGraphic.rectTransform. DoMoveTarget(initialPos, pressDur);
    }


   
    
}
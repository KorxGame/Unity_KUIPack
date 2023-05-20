using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Toggle))]
public class KToggle_Switch1_Normal : MonoBehaviour
{
    public Image bg;
    public RectTransform handle;

    public Color m_isOffColor = new Color(0.547f, 0.547f, 0.547f, 1);
    public Color m_isOnColor = new Color(0.043f, 0.82f, 0.36f, 1);

    public float durTime = 0.3f;
    public int posOffset = 40;

    public AnimationCurve curve = AnimationCurve.EaseInOut(0,0,1,1);
    void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(ison =>
        {
            DoAnim(ison);
        });
    }


    void DoAnim(bool _ison)
    {
        handle?.DOAnchorPos(_ison ? new Vector2(posOffset, 0) : new Vector2(-posOffset, 0), durTime).SetEase(curve);

        bg?.DoUIColor(_ison ? m_isOnColor : m_isOffColor, durTime);
    }


}
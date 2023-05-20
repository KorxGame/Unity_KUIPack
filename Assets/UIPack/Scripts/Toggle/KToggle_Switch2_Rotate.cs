using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KToggle_Switch2_Rotate : MonoBehaviour
{
    public Image bg;
    public RectTransform handle;

    public Color m_isOff = new Color(0.547f, 0.547f, 0.547f, 1);
    public Color m_isOn = new Color(0.043f, 0.82f, 0.36f, 1);

    public float durTime = 0.3f;
    public int posOffset = 40;

    public float zAngleisOff = 0f;
    public float zAngleIson = -179.9f;
    
    public AnimationCurve moveCurve= AnimationCurve.EaseInOut(0,0,1,1);
    public AnimationCurve rotateCurve= AnimationCurve.EaseInOut(0,0,1,1);

    void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(ison => { DoAnim(ison); });
    }

    void DoAnim(bool _ison)
    {
        handle?.DOAnchorPos(_ison ? new Vector2(posOffset, 0) : new Vector2(-posOffset, 0), durTime).SetEase(moveCurve);
        handle?.DOLocalRotate(_ison ? new Vector3(0, 0, zAngleIson) : new Vector3(0, 0, zAngleisOff), durTime).SetEase(rotateCurve);

        bg?.DoUIColor(_ison ? m_isOn : m_isOff, durTime);
    }
}
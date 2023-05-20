using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KToggle_Switch3_Telescoping : MonoBehaviour
{
    public Image bg;
    public RectTransform handle;

    private Color m_isOff = new Color(0.547f, 0.547f, 0.547f, 1);
    private Color m_isOn = new Color(0.043f, 0.82f, 0.36f, 1);

    public float durTime = 0.3f;
    public int posOffset = 40;

    public float xScale = 1.5f;
    public AnimationCurve moveCurve= AnimationCurve.EaseInOut(0,0,1,1);

   void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(ison => { DoAnim(ison); });
    }



    async void DoAnim(bool _ison)
    {
        handle.DOAnchorPos(_ison ? new Vector2(posOffset, 0) : new Vector2(-posOffset, 0), durTime).SetEase(moveCurve);
        bg.DoUIColor(_ison ? m_isOn : m_isOff, durTime);

        await handle.DOScaleX(xScale, durTime / 2);
        await handle.DOScaleX(1f, durTime / 2);
    }
}
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public static class Utils
{
    public static IEnumerator FadeIn(CanvasGroup group, float alpha, float duration)
    {
        var time = 0.0f;
        var originalAlpha = group.alpha;
        while (time < duration)
        {
            time += Time.deltaTime;
            group.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
            yield return new WaitForEndOfFrame();
        }

        group.alpha = alpha;
    }

    public static IEnumerator FadeOut(CanvasGroup group, float alpha, float duration)
    {
        var time = 0.0f;
        var originalAlpha = group.alpha;
        while (time < duration)
        {
            time += Time.deltaTime;
            group.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
            yield return new WaitForEndOfFrame();
        }

        group.alpha = alpha;
    }
    
    
    public static void DoMoveTarget(this RectTransform rectTransform ,Vector2 endPos, float dur)
    {
        rectTransform.DOAnchorPos(endPos, dur);
    }
    
    public static void DoUIColor(this Image image ,Color color, float dur)
    {
        image.DOColor(color, dur);
    }

    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KProgress : MonoBehaviour
{

    public Image amountImage;
    public RectTransform circleRect;

    [Range(0,1)]
    public float value;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetFillAmount(value);
    }

    Vector3 angle = Vector3.zero;
    void SetFillAmount(float value)
    {
        amountImage.fillAmount = value;
        angle.z = value * 360;
        circleRect.localEulerAngles = angle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIHealthBar : MonoBehaviour
{

    // drag object in UI to this field
    public Image bar;
    public static UIHealthBar instance { get; private set; }
    
    float originalSize;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalSize = bar.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {			
        bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }


}

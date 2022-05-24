using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScripts : MonoBehaviour
{
    Slider sliderGauge;
    void Start()
    {
        sliderGauge = GetComponent<Slider>();
    }

    void Update()
    {
        sliderGauge.value += Time.deltaTime;
    }
}

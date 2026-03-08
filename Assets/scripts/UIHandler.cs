using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    // have an dropdown for which rule, and 2 sliders
    public Slider iterationSlider;
    public Slider angleSlider;
    public TMP_Dropdown ruleDropdown;

    public int selectedRule;
    public int iterations;
    public int angle;

    // Start is called before the first frame update
    void Start()
    {
        iterationSlider.onValueChanged.AddListener(OnSliderIterationChanged);
        angleSlider.onValueChanged.AddListener(OnSliderAngleChanged);
        ruleDropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    // updating the values
    void OnSliderIterationChanged(float value)
    {
        iterations = (int)value;
        Debug.Log("iterations: " + value);
    }
    void OnSliderAngleChanged(float value)
    {
        angle = (int)value;
        Debug.Log("angle value: " + value);
    }
    void OnDropdownChanged(int index)
    {
        selectedRule = (int)index;
        Debug.Log("Selected rule index: " + index);
    }
}

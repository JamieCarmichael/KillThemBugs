using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Jamie Carmichael
/// Details: This script sets the mouse sensitivity.
/// </summary>
public class ChangeMouseSensitivity : MonoBehaviour
{
    [Tooltip("This is the mouse sensitivity on the X axis.")]
    [SerializeField] float mouseSensitivityX = 10.0f;
    [Tooltip("This is the mouse sensitivity on the Y axis.")]
    [SerializeField] float mouseSensitivityY = 10.0f;
    [Tooltip("This is the slider controlling the X sensitivity.")]
    [SerializeField] Slider sliderX;
    [Tooltip("This is the slider controlling the Y sensitivity")]
    [SerializeField] Slider sliderY;
    [Tooltip("This is the Playerf aim script that is changed.")]
    [SerializeField] PlayerAim playerAim;

    private void Awake()
    {
        sliderX.onValueChanged.AddListener(HandleSliderValueX);
        sliderY.onValueChanged.AddListener(HandleSliderValueY);
    }

    private void OnEnable()
    {
        mouseSensitivityX = PlayerPrefs.GetFloat("mouseSensitivityX", mouseSensitivityX);
        mouseSensitivityY = PlayerPrefs.GetFloat("mouseSensitivityY", mouseSensitivityY);
        sliderX.value = mouseSensitivityX;
        sliderY.value = mouseSensitivityY;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("mouseSensitivityX", mouseSensitivityX);
        PlayerPrefs.SetFloat("mouseSensitivityY", mouseSensitivityY);
    }

    private void HandleSliderValueX(float xValue)
    {
        mouseSensitivityX = xValue;
        PlayerPrefs.SetFloat("mouseSensitivityX", mouseSensitivityX);
        if (playerAim != null)
        {
            playerAim.MouseSensitivityX = xValue;
        }
    }
    private void HandleSliderValueY(float yValue)
    {
        mouseSensitivityY = yValue;
        PlayerPrefs.SetFloat("mouseSensitivityY", mouseSensitivityY);
        if (playerAim != null)
        {
            playerAim.MouseSensitivityY = yValue;
        }
    }
}

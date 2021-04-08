using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackgroundManager : MonoBehaviour
{
    private Camera _camera;

    [Header("Hue")]
    [Range(0, 1)]
    [SerializeField] float _minHue;
    [Range(0, 1)]
    [SerializeField] float _maxHue;

    [Header("Saturation")]
    [Range(0, 1)]
    [SerializeField] float _minSaturation;
    [Range(0, 1)]
    [SerializeField] float _maxSaturation;

    [Header("Value")]
    [Range(0, 1)]
    [SerializeField] float _minValue;
    [Range(0, 1)]
    [SerializeField] float _maxValue;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        SetRandomBackgroundColor();
    }

    public void SetRandomBackgroundColor()
    {
        _camera.backgroundColor = Random.ColorHSV(_minHue, _maxHue, _minSaturation, _maxSaturation, _minValue, _maxValue);
    }
}

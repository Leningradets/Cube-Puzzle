using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    [Header("CameraSettings")]
    [SerializeField] private float _mouseZoomSens;
    [SerializeField] private float _minCameraSize;
    [SerializeField] private float _maxCameraSize;
    private Camera _camera;

    float _lastDistanceBetweenTouches;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }


    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            _camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * _mouseZoomSens;
            CorrectCameraSize();
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount == 2)
        {
            var touch1 = Input.GetTouch(0);
            var touch2 = Input.GetTouch(1);

            if (touch2.phase == TouchPhase.Began)
            {
                _lastDistanceBetweenTouches = Vector2.Distance(touch1.position, touch2.position);
            }

            if(touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistanceBetweenTouches = Vector2.Distance(touch1.position, touch2.position);

                float zoom = currentDistanceBetweenTouches / _lastDistanceBetweenTouches;

                _camera.orthographicSize /= zoom;

                _lastDistanceBetweenTouches = currentDistanceBetweenTouches;
                CorrectCameraSize();
            }
        }
#endif
    }
    private void CorrectCameraSize()
    {
        if (_camera.orthographicSize > _maxCameraSize)
        {
            _camera.orthographicSize = _maxCameraSize;
        }

        if (_camera.orthographicSize < _minCameraSize)
        {
            _camera.orthographicSize = _minCameraSize;
        }
    }
}

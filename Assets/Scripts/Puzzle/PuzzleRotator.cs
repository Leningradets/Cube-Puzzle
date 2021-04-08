using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WinChecker))]
public class PuzzleRotator : MonoBehaviour
{
    [SerializeField] private float _mouseSens;
    [SerializeField] private float _touchSens;

    private WinChecker _winChecker;

    private void Awake()
    {
        _winChecker = GetComponent<WinChecker>();
    }

    private void OnEnable()
    {
        _winChecker.Winned += OnWinned;
    }

    private void OnWinned()
    {
        enabled = false;
    }

    private void OnDisable()
    {
        _winChecker.Winned -= OnWinned;
    }

    public void RotateRandom()
    {
        Rotate(Random.Range(0, 360), Random.Range(0, 360));
    }

    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (Input.GetMouseButton(0))
        {
            var horizontal = -Input.GetAxis("Mouse X") * _mouseSens * Time.deltaTime;
            var vertical = Input.GetAxis("Mouse Y") * _mouseSens * Time.deltaTime;

            Rotate(horizontal, vertical);
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                var horizontal = -touch.deltaPosition.x * _touchSens * Time.deltaTime;
                var vertical = touch.deltaPosition.y * _touchSens * Time.deltaTime;

                Rotate(horizontal, vertical);
            }
        }
#endif
    }

    public void Rotate(float rotationUp, float rotationRight, Space relativeTo = Space.World)
    {
        transform.Rotate(Vector3.up, rotationUp, relativeTo);
        transform.Rotate(Vector3.right, rotationRight, relativeTo);
    }

    public void SetConfig(float mouseSens, float touchSens)
    {
        _mouseSens = mouseSens;
        _touchSens = touchSens;
    }
}

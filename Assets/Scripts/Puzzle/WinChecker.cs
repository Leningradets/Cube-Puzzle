using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinChecker : MonoBehaviour
{
    public event UnityAction Winned;

    [SerializeField] private float _accuracy;
    [SerializeField] private float _timeToWin;
    [SerializeField] private float _winAnimationSpeed;
    private float timer;

    private bool isWinned = false;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (!isWinned)
        {
            if (CheckAngle())
            {
                timer += Time.deltaTime;

                if (timer >= _timeToWin)
                {
                    Winned?.Invoke();
                    Debug.Log("Win");
                    isWinned = true;
                    timer = 0;
                }
            }
            else
            {
                timer = 0;
            }
        }
        else
        {
            _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.identity, _winAnimationSpeed * Time.deltaTime);
        }
    }

    private bool CheckAngle()
    {
        return (Vector3.Angle(_transform.forward, Vector3.forward) <= _accuracy || Vector3.Angle(_transform.forward, Vector3.back) <= _accuracy);
    }
}

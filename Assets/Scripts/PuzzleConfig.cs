using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PuzzleConfig")]
public class PuzzleConfig : ScriptableObject
{
    [Header("Generator")]
    [SerializeField] private PuzzleCube _cube;
    [SerializeField] private bool Distort;

    [Header("Input")]
    [SerializeField] private float _mouseSens;
    [SerializeField] private float _touchSens;

    [Header("Win")]
    [SerializeField] private float _accuracy;
    [SerializeField] private float _time;
    [SerializeField] private float _animationSpeed;
}

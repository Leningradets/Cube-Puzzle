using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzleGenerator), typeof(PuzzleRotator), typeof(WinChecker))]
public class Puzzle : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    [SerializeField] private PuzzleConfig _config;

    private PuzzleGenerator _generator;
    private PuzzleRotator _rotator;

    private void Awake()
    {
        _generator = GetComponent<PuzzleGenerator>();
        _rotator = GetComponent<PuzzleRotator>();
    }

    public void SetTexture(Texture2D texture)
    {
        _texture = texture;
    }

    public void Generate(Texture2D texture)
    {
        SetTexture(texture);
        Generate();
    }

    public void Generate()
    {
        _generator.Generate(_texture);
        //_rotator.RotateRandom();
    }

    public void ApplyConfig()
    {

    }
}

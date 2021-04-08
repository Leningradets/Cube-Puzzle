using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzleGenerator))]
public class PuzzleSegment : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    private PuzzleGenerator _generator;

    private void Awake()
    {
        _generator = GetComponent<PuzzleGenerator>();
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
    }
}

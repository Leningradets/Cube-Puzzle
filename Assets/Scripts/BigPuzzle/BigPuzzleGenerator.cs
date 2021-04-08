using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPuzzleGenerator : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    [SerializeField] private Vector2Int _segmentSize;

    public int ColomnCount => _texture.width / _segmentSize.x;
    public int RowCount => _texture.height / _segmentSize.y;

    private Color[] _pixels;
    private Texture2D[,] _segmentsTextures;
    private PuzzleSegment[,] _segments;

    private void Start()
    {     
        InitSegments();
        SetTexturesToSegments(SliceTexture());
        Generate();
    }

    private void InitSegments()
    {
        _segments = new PuzzleSegment[ColomnCount, RowCount];

        for (int x = 0; x < _segments.GetLength(0); x++)
        {
            for (int y = 0; y < _segments.GetLength(1); y++)
            {
                var segmentGameObject = new GameObject($"Segment {x}, {y}");
                segmentGameObject.transform.position = new Vector3(x * _segmentSize.x - _texture.width / 2, y * _segmentSize.y - _texture.width / 2, 0);
                _segments[x, y] = segmentGameObject.AddComponent<PuzzleSegment>();
            }
        }
    }

    private void Generate()
    {
        for (int x = 0; x < _segments.GetLength(0); x++)
        {
            for (int y = 0; y < _segments.GetLength(1); y++)
            {
                _segments[x, y].Generate();
            }
        }
    }

    private Texture2D[,] SliceTexture()
    {
        Texture2D[,] textureSegments = new Texture2D[ColomnCount, RowCount];


        for (int x = 0; x < ColomnCount; x++)
        {
            for(int y = 0; y < RowCount; y++)
            {
                var textureSegmentPixels = _texture.GetPixels(x * _segmentSize.x, y * _segmentSize.y, _segmentSize.x, _segmentSize.y);
                textureSegments[x, y] = new Texture2D(_segmentSize.x, _segmentSize.y);
                textureSegments[x, y].SetPixels(textureSegmentPixels);
            }
        }

        return textureSegments;
    }

    private void SetTexturesToSegments(Texture2D[,] textures)
    {
        for (int x = 0; x < _segments.GetLength(0); x++)
        {
            for (int y = 0; y < _segments.GetLength(1); y++)
            {
                _segments[x, y].SetTexture(textures[x, y]);
            }
        }
    }
}

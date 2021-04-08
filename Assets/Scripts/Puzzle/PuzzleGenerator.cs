using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGenerator : MonoBehaviour
{
    private Texture2D _texture;
    private Color[] _pixels;
    private Transform _transform;

    [SerializeField] private PuzzleCube _cube;
    [SerializeField] private bool _distort;

    private void Start()
    {
        _transform = transform;
    }

    public void Generate()
    {
        _pixels = _texture.GetPixels();

        PlaceCubes();
        if (_distort)
        {
            Distort(_texture.width / 2);
        }
    }

    public void Generate(Texture2D texture)
    {
        _texture = texture;

        Generate();
    }

    private void PlaceCubes()
    {
        for (int x = 0; x < _texture.width; x++)
        {
            for (int y = 0; y < _texture.height; y++)
            {
                if (_pixels[y * _texture.width + x].a >= 0.9)
                {
                    PlaceCube(x, y);
                }
            }
        }
    }

    private void PlaceCube(int x, int y)
    {
        var cube = Instantiate(_cube, new Vector3(x - _texture.width / 2, y - _texture.height / 2, 0), Quaternion.identity, _transform);
        cube.name = "cube" + x + ", " + y;
        cube.SetColor(_pixels[y * _texture.width + x]);
    }

    private void Distort(float amplitude)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var cube = _transform.GetChild(i);
            cube.transform.Translate(Vector3.forward * Random.Range(-amplitude, amplitude));
        }
    }
}

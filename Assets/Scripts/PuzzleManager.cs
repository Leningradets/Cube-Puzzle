using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Texture2D[] _textures;
    [SerializeField] private int _currentTexture;

    private Puzzle _puzzle;
    
    void Start()
    {
        _puzzle = GetComponentInChildren<Puzzle>();

        _currentTexture = Random.Range(0, _textures.Length);

        if(_currentTexture < _textures.Length)
        {
            _puzzle.Generate(_textures[_currentTexture]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCube : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Transform _transform;
    private Transform _parentTransform;
    [Range(0, 1)]
    [SerializeField] private float _springiness = 0.5f;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _transform = transform;
        _parentTransform = transform.parent.transform;
    }

    private void Update()
    {
        Quaternion targetRotation;

        if(_parentTransform.forward.z >= 0)
        {
            targetRotation = Quaternion.Euler(0, 0, _parentTransform.rotation.eulerAngles.z);
        }
        else
        {
            targetRotation = Quaternion.Euler(0, 0, -_parentTransform.rotation.eulerAngles.z);
        }

        _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRotation, _springiness);
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}

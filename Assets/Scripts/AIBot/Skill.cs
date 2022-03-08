using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Skill : MonoBehaviour
{
    [SerializeField] private Color _color;

    private MeshRenderer _meshRenderer;

    public Color Color => _color;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _meshRenderer.material.color = _color;
    }
}

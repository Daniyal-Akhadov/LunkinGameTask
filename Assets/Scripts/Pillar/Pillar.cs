using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] private State _currentState;
    [SerializeField] private MeshRenderer _renderer;

    [SerializeField] private Color _currentColor;

    public State CurrentState => _currentState;
    public Color CurrentColor => _currentColor;

    public void SetState(State state)
    {
        _currentState = state;
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
        _currentColor = color;
    }
}

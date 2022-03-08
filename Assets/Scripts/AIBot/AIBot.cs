using UnityEngine;

[RequireComponent(typeof(AIBotRepairing))]
[RequireComponent(typeof(AIBotMover))]
public class AIBot : MonoBehaviour
{
    [SerializeField] private Skill[] _skills;

    private PillarColorChanger _collorChanger;
    private AIBotMover _mover;

    private void Awake()
    {
        _collorChanger = FindObjectOfType<PillarColorChanger>();
        _mover = GetComponent<AIBotMover>();
    }

    private void OnEnable()
    {
        _collorChanger.ColorChanged += OnColorChanged;
    }

    private void OnDisable()
    {
        _collorChanger.ColorChanged -= OnColorChanged;
    }

    private void OnColorChanged(Pillar pillar)
    {
        if (DetermineCompatibility(pillar))
        {
            if (pillar.CurrentState != State.Repaired) 
                _mover.MoveTo(pillar);
        }
    }

    private bool DetermineCompatibility(Pillar pillar)
    {
        if (pillar == null)
            return false;

        bool result = false;

        foreach (var skill in _skills)
        {
            if (skill.Color == pillar.CurrentColor)
            {
                result = true;
                break;
            }
        }

        return result;
    }
}
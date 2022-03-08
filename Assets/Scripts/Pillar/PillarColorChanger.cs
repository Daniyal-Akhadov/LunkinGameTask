using UniRx;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class PillarColorChanger : MonoBehaviour
{
    [SerializeField] private float _cooldown;

    [SerializeField] private Color[] _colors = { Color.red, Color.green, Color.blue };

    public event Action<Pillar> ColorChanged;

    private PillarStateChecker _stateChecker;
    private IDisposable _disposable;

    private void Awake()
    {
        _stateChecker = GetComponent<PillarStateChecker>();
    }

    private void OnEnable()
    {
        _disposable = Observable.Timer(TimeSpan.FromSeconds(_cooldown))
             .Repeat()
             .Where(_ =>
             {
                 _stateChecker.CheckAllPillars();
                 return _stateChecker.IsEveryoneFixed;
             })
             .Subscribe(_ =>
             {
                 var fixedPillar = _stateChecker.GetRandomFixedPillar();
                 ChangeColor(ref fixedPillar);
                 fixedPillar.SetState(State.NotFixed);
             })
             .AddTo(this);
    }

    private void OnDisable()
    {
        _disposable?.Dispose();
    }

    private void ChangeColor(ref Pillar pillar)
    {
        if (pillar != null)
        {
            var targetColor = GetRandomColor();
            pillar.SetColor(targetColor);
            ColorChanged?.Invoke(pillar);
        }
    }

    private Color GetRandomColor()
    {
        int randomIndex = Random.Range(minInclusive: 0, _colors.Length);
        return _colors[randomIndex];
    }
}

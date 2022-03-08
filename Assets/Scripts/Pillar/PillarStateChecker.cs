using UnityEngine;

public class PillarStateChecker : MonoBehaviour
{
    [SerializeField] private Pillar[] _pillars;

    public bool IsEveryoneFixed
    {
        get
        {
            return FixedPillarCount == _pillars.Length;
        }
    }

    public int FixedPillarCount { get; private set; }

    private void Start()
    {
        CheckAllPillars();
    }

    public void CheckAllPillars()
    {
        FixedPillarCount = 0;

        foreach (var pillar in _pillars)
        {
            if (pillar.CurrentState == State.Fixed)
            {
                FixedPillarCount++;
            }
        }
    }

    public Pillar GetRandomFixedPillar()
    {
        Pillar result = null;

        while (result == null)
        {
            var randomIndex = Random.Range(minInclusive: 0, _pillars.Length);
            var randomFixedPillar = _pillars[randomIndex];

            if (randomFixedPillar.CurrentState == State.Fixed)
                result = randomFixedPillar;
        }

        return result;
    }
}

public enum State
{
    Fixed,
    NotFixed,
    Repaired
}
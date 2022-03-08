using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class AIBotMover : MonoBehaviour
{
    [SerializeField] private float _timeToReach = 3f;

    private Rigidbody _rigidbody;
    private Vector3 _initialPoint;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _initialPoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var pillar = other.GetComponent<Pillar>();

        if (pillar)
        {
            ComeBack();
        }
    }

    public void MoveTo(Pillar pillar)
    {
        if (pillar == null)
            return;

        pillar.SetState(State.Repaired);
        var target = pillar.transform.position;
        target.y = transform.position.y;
        _rigidbody.DOMove(target, _timeToReach);
    }

    private void ComeBack()
    {
        _rigidbody.DOMove(_initialPoint, _timeToReach);
    }
}

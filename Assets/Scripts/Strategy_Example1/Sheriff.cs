using System;
using UnityEngine;

public class Sheriff : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private IMover _mover;

    public Transform Transform => transform;
    public float Speed => _speed;


    private void Update()
    {
        _mover?.Update(Time.deltaTime);
    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }
}

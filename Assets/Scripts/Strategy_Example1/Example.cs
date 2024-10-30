using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private Sheriff _sheriff;
    [SerializeField] private Transform _target;
    [SerializeField] private List<Transform> _patrolPoints;

    private void Awake()
    {
        _sheriff.SetMover(new NoMovePattern());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _sheriff.SetMover(new NoMovePattern());
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _sheriff.SetMover(new PointByPointMover(_sheriff, _patrolPoints.Select(point => point.position)));
        }

        if ( Input.GetKeyDown(KeyCode.S))
        {
            _sheriff.SetMover(new MoveToTargetPattern(_sheriff, _target));
        }
    }
}

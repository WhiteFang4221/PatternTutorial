using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementBehaivourSwitcher : MonoBehaviour
{
    [SerializeField] private Sheriff _sheriff;
    [SerializeField] private Transform _target;
    [SerializeField] private List<Transform> _patrolPoints;

    private MovementStrategyFactory _factory ;

    private void Awake()
    {
        _factory = new MovementStrategyFactory(_target, _patrolPoints);
        SetMover(MoverTypes.NoMove);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetMover(MoverTypes.NoMove);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SetMover(MoverTypes.PointByPoint);
        }

        if ( Input.GetKeyDown(KeyCode.S))
        {
            SetMover(MoverTypes.TargetFollower);
        }
    }

    private void SetMover (MoverTypes moverType) => _sheriff.SetMover(_factory.Get(moverType, _sheriff));
}

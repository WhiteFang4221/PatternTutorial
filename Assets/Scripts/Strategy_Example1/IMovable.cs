using UnityEngine;

public interface IMovable
{
    Transform Transform { get; }
    public float Speed { get; }
}

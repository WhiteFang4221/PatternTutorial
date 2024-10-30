using System.Collections.Generic;
using UnityEngine;

public class CharacterCheckerExample : MonoBehaviour
{
    [SerializeField] private Ork _ork;
    [SerializeField] private List<Human> _humans;

    private void Awake()
    {
        foreach (Human human in _humans)
        {
            human.Initialize(new NoViewPattern(), character => character is Ork);
        }

        _ork.Initialize(new SearchAroundPattern(_ork.transform, 5), character => character is Human);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_ork.transform.position, 5);
    }
}

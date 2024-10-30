using System.Collections.Generic;
using UnityEngine;

public class FrontSearchPattern : ICharacterFinder
{
    private Transform _center;
    private float _viewRange;

    public FrontSearchPattern(Transform center, float viewRange)
    {
        _center = center;
        _viewRange = viewRange;
    }

    public IEnumerable<Character> Find()
    {
        RaycastHit[] hits = Physics.RaycastAll(new Ray(_center.position, _center.forward), _viewRange);
        List<Character> findedCharacters = new List<Character>();

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.TryGetComponent(out Character character))
            {
                if (character.transform != _center)
                {
                    findedCharacters.Add(character);
                }
            }
        }

        return findedCharacters;
    }
}

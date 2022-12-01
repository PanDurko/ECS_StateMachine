using Leopotam.Ecs;
using UnityEngine;

public class MoveState : IEcsRunSystem
{
    private EcsFilter<PlayerTag, MoveTag> _isMovingFilter; 

    public void Run()
    {
        foreach (var i in _isMovingFilter)
        {
            Debug.Log("Move");
        }
    }
}

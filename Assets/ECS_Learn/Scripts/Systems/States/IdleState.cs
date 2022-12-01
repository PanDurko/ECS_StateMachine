using Leopotam.Ecs;
using UnityEngine;

public class IdleState : IEcsRunSystem
{
    private EcsFilter<PlayerTag, IdleTag> _isIdleFilter; 
    
    public void Run()
    {
        foreach (var i in _isIdleFilter)
        {
            Debug.Log("Idle");
        }
    }
}

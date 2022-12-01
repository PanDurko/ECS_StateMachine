using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsBootstrap : MonoBehaviour
{
    private EcsWorld _world; 
    private EcsSystems _systems; 
    
    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world); 
        
        AddSystems();
        
        _systems
            .ConvertScene()
            .Init();
    }

    private void AddSystems()
    {
        _systems
            .Add(new PlayerInitSystem())
            .Add(new MoveInputSystem())
            .Add(new MoveSystem())
            .Add(new MoveStateListener())
            .Add(new MoveState())
            .Add(new IdleStateListener())
            .Add(new IdleState());
    }
    
    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        _world?.Destroy();
        _world = null; 
        _systems?.Destroy();
        _systems = null;
    }
}

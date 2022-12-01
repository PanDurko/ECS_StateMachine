using Leopotam.Ecs;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsFilter<PlayerTag, PlayerComponent> _playerFilter; 
    
    public void Init()
    {
        foreach (var i in _playerFilter)
        {
            ref EcsEntity playerEntities = ref _playerFilter.GetEntity(i);
            ref PlayerComponent playerComponent = ref _playerFilter.Get2(i);

            playerEntities.Get<IdleTag>();
            playerComponent.Player = playerEntities; 
        }
    }
}

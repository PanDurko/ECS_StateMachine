using Leopotam.Ecs;

public class IdleStateListener : IEcsRunSystem
{
    private EcsFilter<PlayerTag> _playersFilter;  
    private EcsFilter<PlayerTag, MoveInputComponent, PlayerComponent> _idleStateFilter;
    
    public void Run()
    {
        foreach (var i in _idleStateFilter)
        {
            ref MoveInputComponent input = ref _idleStateFilter.Get2(i);
            ref PlayerComponent playerComponent = ref _idleStateFilter.Get3(i); 
            
            TryChangeToIdleState(input, playerComponent);
        }
    }

    private void TryChangeToIdleState(MoveInputComponent input, PlayerComponent playerComponent)
    {
        EcsEntity player = playerComponent.Player; 
        
        if (player.Has<MoveTag>() && input.Input.magnitude == 0)
        {
            player.Del<MoveTag>();
            player.Get<IdleTag>();
        }
    }
}

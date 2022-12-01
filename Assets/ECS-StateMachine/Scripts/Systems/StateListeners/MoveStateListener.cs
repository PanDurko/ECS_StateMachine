using Leopotam.Ecs;

public class MoveStateListener : IEcsRunSystem
{
    private EcsFilter<PlayerTag, IdleTag> _playersFilter;  
    private EcsFilter<PlayerTag, IdleTag, MoveInputComponent, PlayerComponent> _moveStateFilter;
    
    public void Run()
    {
        foreach (var i in _moveStateFilter)
        {
            ref MoveInputComponent input = ref _moveStateFilter.Get3(i);
            ref PlayerComponent playerComponent = ref _moveStateFilter.Get4(i); 

            TryChangeToMoveState(input, playerComponent);
        }
    }

    private void TryChangeToMoveState(MoveInputComponent input, PlayerComponent playerComponent)
    {
        EcsEntity player = playerComponent.Player; 
    
        if (input.Input.magnitude > 0)
        {
            player.Del<IdleTag>();
            player.Get<MoveTag>();
        }
    }
}

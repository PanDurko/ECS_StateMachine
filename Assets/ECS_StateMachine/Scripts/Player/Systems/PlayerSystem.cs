using ECS_StateMachine.Scripts.GameInput.Components;
using ECS_StateMachine.Scripts.Player.Components;
using ECS_StateMachine.Scripts.Player.States;
using Leopotam.Ecs;

namespace ECS_StateMachine.Scripts.Player.Systems
{
    public class PlayerSystem : IEcsRunSystem
    {
        private EcsFilter<StateComponent, InputComponent, PlayerComponent> _playerStateFilter;

        public void Run()
        {
            foreach (var i in _playerStateFilter)
            {
                ref InputComponent move = ref _playerStateFilter.Get2(i);
                ref PlayerComponent player = ref _playerStateFilter.Get3(i);

                if (move.Input.magnitude == 0)
                {
                    player.Entity.Get<IdleState>();
                    return; 
                }

                player.Entity.Get<MoveState>();
            }
        }
    }
}
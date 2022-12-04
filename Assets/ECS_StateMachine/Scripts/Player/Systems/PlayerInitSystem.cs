using ECS_StateMachine.Scripts.Player.Components;
using ECS_StateMachine.Scripts.Player.States;
using Leopotam.Ecs;

namespace ECS_StateMachine.Scripts.Player.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsFilter<PlayerComponent> _playersFilter; 

        public void Init()
        {
            foreach (var i in _playersFilter)
            {
                ref EcsEntity playerEntity = ref _playersFilter.GetEntity(i);
                ref PlayerComponent playerComponent = ref _playersFilter.Get1(i);
                ref StateComponent stateMachine = ref playerEntity.Get<StateComponent>();
                
                playerComponent.Entity = playerEntity;
                
                playerEntity.Get<IdleState>();
                
                stateMachine.CurrentState = StateType.Idle; 
            }
        }
    }
}
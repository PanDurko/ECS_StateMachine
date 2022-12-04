using ECS_StateMachine.Scripts.GameInput.Components;
using ECS_StateMachine.Scripts.Player.Components;
using ECS_StateMachine.Scripts.Player.States;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS_StateMachine.Scripts.Player.Systems
{
    public class IdleStateSystem : IEcsRunSystem
    {
        private EcsFilter<IdleState, StateComponent, InputComponent, PlayerComponent> _idleStateFilter; 

        public void Run()
        {
            foreach (var i in _idleStateFilter)
            {
                ref StateComponent stateMachine = ref _idleStateFilter.Get2(i);
                ref InputComponent move = ref _idleStateFilter.Get3(i);
                ref PlayerComponent player = ref _idleStateFilter.Get4(i);

                if (move.Input.magnitude > 0)
                {
                    player.Entity.Del<IdleState>();
                    stateMachine.CurrentState = StateType.Move; 
                    return; 
                }
                
                Debug.Log("Idle");
            }
        }
    }
}
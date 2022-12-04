using ECS_StateMachine.Scripts.GameInput.Components;
using ECS_StateMachine.Scripts.Player.Components;
using ECS_StateMachine.Scripts.Player.States;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS_StateMachine.Scripts.Player.Systems
{
    public class MoveStateSystem : IEcsRunSystem
    {
        private EcsFilter<MoveState, StateComponent, InputComponent, PlayerComponent> _moveStateFilter; 

        public void Run()
        {
            foreach (var i in _moveStateFilter)
            {
                ref StateComponent stateMachine = ref _moveStateFilter.Get2(i);
                ref InputComponent move = ref _moveStateFilter.Get3(i);
                ref PlayerComponent player = ref _moveStateFilter.Get4(i);

                if (move.Input.magnitude == 0)
                {
                    player.Entity.Del<MoveState>();
                    stateMachine.CurrentState = StateType.Idle;
                    return; 
                }

                Debug.Log("Move");
            }
        }
    }
}
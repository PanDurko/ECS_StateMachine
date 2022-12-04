using ECS_StateMachine.Scripts.GameInput.Components;
using ECS_StateMachine.Scripts.Move.Components;
using ECS_StateMachine.Scripts.Player.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS_StateMachine.Scripts.Move.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, InputComponent, TransformComponent> _moveFilter; 

        public void Run()
        {
            foreach (var i in _moveFilter)
            {
                ref MoveComponent moveComponent = ref _moveFilter.Get1(i);
                ref InputComponent moveInput = ref _moveFilter.Get2(i);
                ref TransformComponent player = ref _moveFilter.Get3(i);
                
                Move(moveComponent, moveInput, player);
            }
        }

        private void Move(MoveComponent moveComponent, 
            InputComponent moveInput, 
            TransformComponent player)
        {
            Vector3 direction = (player.transform.forward * moveInput.Input.y) 
                                + (player.transform.right * moveInput.Input.x);

            moveComponent.controller.Move(direction * (moveComponent.moveSpeed * Time.deltaTime));
        }
    }
}
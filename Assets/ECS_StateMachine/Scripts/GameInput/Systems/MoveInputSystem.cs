using ECS_StateMachine.Scripts.GameInput.Components;
using Leopotam.Ecs;
using UnityEngine; 

namespace ECS_StateMachine.Scripts.GameInput.Systems
{
    public class MoveInputSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _inputFilter;

        private float _moveInputX; 
        private float _moveInputY;
        
        public void Run()
        {
            UpdateInput();
            
            foreach (var i in _inputFilter)
            {
                ref InputComponent move = ref _inputFilter.Get1(i);

                move.Input.x = _moveInputX;
                move.Input.y = _moveInputY; 
            }
        }

        private void UpdateInput()
        {
            _moveInputX = Input.GetAxis("Horizontal");
            _moveInputY = Input.GetAxis("Vertical"); 
        }
    }
}
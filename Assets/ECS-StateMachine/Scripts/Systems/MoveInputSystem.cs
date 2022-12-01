using Leopotam.Ecs;
using UnityEngine;

public class MoveInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerTag, MoveInputComponent> _inputFilter;

    private float InputX; 
    private float InputY;
    
    public void Run()
    {
        UpdateInput();
        
        foreach (var i in _inputFilter)
        {
            ref MoveInputComponent inputComponent = ref _inputFilter.Get2(i);

            inputComponent.Input.x = InputX;
            inputComponent.Input.z = InputY; 
        }
    }

    private void UpdateInput()
    {
        InputX = Input.GetAxis("Horizontal"); 
        InputY = Input.GetAxis("Vertical");
    }
}

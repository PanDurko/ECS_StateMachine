using UnityEngine;
using Leopotam.Ecs;

public class MoveSystem : IEcsRunSystem
{
    private EcsFilter<PlayerTag, MoveInputComponent, MoveComponent, TransformComponent> _movableFilter; 

    public void Run()
    {
        foreach (var i in _movableFilter)
        {
            ref MoveInputComponent inputComponent = ref _movableFilter.Get2(i);
            ref MoveComponent playerMovable = ref _movableFilter.Get3(i);
            ref TransformComponent player = ref _movableFilter.Get4(i);

            Move(playerMovable, inputComponent, player);
        }
    }

    private void Move(MoveComponent movable, 
        MoveInputComponent inputComponent,
        TransformComponent player)
    {
        Vector3 direction = (player.ObjectTransform.forward * inputComponent.Input.x)
                            + (player.ObjectTransform.right * inputComponent.Input.z);

        movable.Controller.Move(direction * movable.MoveSpeed * Time.deltaTime);
    }
}

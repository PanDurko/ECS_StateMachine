using System;
using UnityEngine;

namespace ECS_StateMachine.Scripts.Move.Components
{
    [Serializable]
    public struct MoveComponent
    {
        public float moveSpeed; 
        
        public CharacterController controller;
        
        [HideInInspector] public Vector3 velocity; 
    }
}
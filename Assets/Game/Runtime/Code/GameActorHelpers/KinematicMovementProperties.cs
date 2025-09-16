using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorHelpers
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     This provides kinematic movement from a monobehavior, for GameActors. Used mostly by bullets.
    /// Changelog:       
    /// </summary>
    public class KinematicMovementProperties : MonoBehaviour, IInputProvider, IGameActorPhysics
    {
        [SerializeField] protected Vector2 _intention;
        [SerializeField] protected float _acceleration;
        [SerializeField] protected bool _attack;

        public Vector2 Intention
        {
            get => _intention;
            set => _intention = value;
        }

        public bool Attack
        {
            get => _attack;
            set => _attack = value;
        }

        public float Acceleration => _acceleration;
    }
}
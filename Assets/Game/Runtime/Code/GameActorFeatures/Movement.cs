using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.PropertyDrawersCollection;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     
    /// Changelog:       
    /// </summary>
    public class Movement : GameActorFeatureBase
    {
        [SerializeField, ObjectType(typeof(IGameActorPhysics))]
        protected UnityEngine.Object _physicsAsset;

        [SerializeField, ObjectType(typeof(IInputProvider))]
        protected UnityEngine.Object _inputProvider;

        [SerializeField] protected Rigidbody2D _rb2d;

        private IGameActorPhysics cPhysicsAsset;
        private IInputProvider cInputProvider;

        public IInputProvider inputProvider => cInputProvider;

        private void OnEnable()
        {
            cPhysicsAsset = _physicsAsset as IGameActorPhysics;
            cInputProvider = _inputProvider as IInputProvider;
        }

        public override void DoUpdate(GameActor a, float t)
        {

        }

        public override void DoFixedUpdate(GameActor a, float t)
        {
            _rb2d.linearVelocity = cInputProvider.Intention * cPhysicsAsset.Acceleration;
        }
    }
}
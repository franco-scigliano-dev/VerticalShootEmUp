using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Hitpoints base GameActorFeature that manages collisions to keep track of health and
    ///                  also provides hit points on collision to other game actors.
    /// Changelog:       
    /// </summary>
    public abstract class HitPointsBase : GameActorFeatureBase
    {
        [SerializeField] protected string _oneHitDestroyTag;

        protected virtual int BaseHealth
        {
            get;
        }

        protected virtual int Health
        {
            get;
            set;
        }

        private void OnEnable()
        {
            CollidersRegister.OnCollision += HandleCollisions;
            Refill();
        }
        public void Refill()
        {
            Health = BaseHealth;
            HandleHealthChanged();
        }
        private void OnDisable()
        {
            CollidersRegister.OnCollision -= HandleCollisions;
        }

        private void HandleCollisions(GameActor collider, GameActor collided, GameObject collidedGameObject)
        {
            if (collider == _gameActor)
            {
                HitPointsBase d;
                if (collided != null && collided.GetFeature(out d))
                {
                    Health -= d.BaseHealth;
                }
                else if (collidedGameObject.CompareTag(_oneHitDestroyTag))
                {
                    Health = 0;
                }

                HandleHealthChanged();
            }
        }

        protected virtual void HandleHealthChanged()
        {
            
        }
        public override void DoFixedUpdate(GameActor a, float t)
        {
            if (Health <= 0)
            {
                a.SetDestroyed();
            }
        }
    }
}

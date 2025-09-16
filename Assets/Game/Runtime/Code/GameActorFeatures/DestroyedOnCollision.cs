using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Listens to collision events and destroys the object on contact with a valid collider.
    /// Changelog:       
    /// </summary>
    public class DestroyedOnCollision : GameActorFeatureBase
    {
        private void OnEnable()
        {
            CollidersRegister.OnCollision += HandleCollision;
        }

        private void OnDisable()
        {
            CollidersRegister.OnCollision -= HandleCollision;
        }

        private void HandleCollision(GameActor collider, GameActor collided, GameObject collidedGameObject)
        {
            if (_gameActor == collider)
            {
                _gameActor.SetDestroyed();
            }
        }
    }
}
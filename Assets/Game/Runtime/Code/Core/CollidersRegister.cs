using System;
using com.fscigliano.CommonExtensions;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Core
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Main collider registration system. This provides a cached registry for GameActor's
    ///                  colliders, to retrieve them with the collider as key.
    /// Changelog:       
    /// </summary>
    public class CollidersRegister:Registerer<Rigidbody2D, GameActor>
    {
        public static Action<GameActor, GameActor, GameObject> OnCollision;
        public static CollidersRegister Instance { get; } = new ();

        public static void TriggerCollision(GameActor collider, GameActor collided, GameObject collidedGameObject)
        {
            OnCollision?.Invoke(collider, collided, collidedGameObject);
        }
    }
}
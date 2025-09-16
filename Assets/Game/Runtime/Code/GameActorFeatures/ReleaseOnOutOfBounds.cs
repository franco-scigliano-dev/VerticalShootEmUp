using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     This components registers statically the bounds of the game to let the gameActors know
    ///                  when it's crossed to be released.
    /// Changelog:       
    /// </summary>
    public class ReleaseOnOutOfBounds : GameActorFeatureBase
    {
		private bool insideGameplay = false;

        protected override void HandleDoInit(GameActor gameActor)
        {
            base.HandleDoInit(gameActor);
            insideGameplay = false;
        }

        private void FixedUpdate()
        {
            Vector3 p = transform.position;
            var bounds = GameplayBounds.Gameplay.bounds;

            bool isInside = p.x >= bounds.min.x && p.x <= bounds.max.x &&
                            p.y >= bounds.min.y && p.y <= bounds.max.y;

            if (isInside && !insideGameplay)
            {
                // Mark actor as "inside gameplay" once
                insideGameplay = true;
            }
            else if (!isInside && insideGameplay)
            {
                // If it was inside and now it’s outside then release
                _gameActor.SetReleased();
            }
        }
    }
}
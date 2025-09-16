using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Sends a gameActor to it's pool, without formally destroy it, after an amount of time passed.
    /// Changelog:       
    /// </summary>
    public class DestroyedOnTime : GameActorFeatureBase
    {
        [SerializeField] protected float _time;

        public override void DoUpdate(GameActor a, float t)
        {
            if (t >= _time)
            {
                _gameActor.SetReleased();
            }
        }
    }
}
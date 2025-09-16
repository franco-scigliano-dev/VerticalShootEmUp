using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Base GameActorFeature monobehaviour, to be extended by every monobehaviour based feature.
    /// Changelog:       
    /// </summary>
    public class GameActorFeatureBase : MonoBehaviour, IGameActorFeature
    {
        protected GameActor _gameActor;

        public void DoInit(GameActor a)
        {
            _gameActor = a;
            HandleDoInit(a);
        }

        protected virtual void HandleDoInit(GameActor gameActor)
        {

        }

        public virtual void DoUpdate(GameActor a, float t)
        {

        }

        public virtual void DoFixedUpdate(GameActor a, float t)
        {

        }
    }
}
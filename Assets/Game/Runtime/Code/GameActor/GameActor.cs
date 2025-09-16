using System.Collections.Generic;
using com.fscigliano.VerticalShootEmUp.Events.Custom;
using com.fscigliano.VerticalShootEmUp.Pool;
using com.fscigliano.PropertyDrawersCollection;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActors
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Core component implementing the decorator pattern for game actors. Manages a list of
    ///                  IGameActorFeature components with controlled update and initialization order.
    /// Changelog:       
    /// </summary>
    public class GameActor : BasePooleable
    {
        [SerializeField] protected GameActorIDAsset _id;
        [SerializeField, ObjectType(typeof(IGameActorFeature))]
        protected List<UnityEngine.Object> _gameActorFeatures = new List<UnityEngine.Object>();

        private readonly List<IGameActorFeature> gameActorFeatures = new List<IGameActorFeature>();

        [SerializeField] protected float _time;
        [SerializeField] protected GameActorEvt _onGameActorDestroyedEvt;
        
        public GameActorIDAsset Id => _id;
        protected override void DoOnEnable()
        {
            _time = 0;
            gameActorFeatures.Clear();
            for (int i = 0; i < _gameActorFeatures.Count; i++)
            {
                gameActorFeatures.Add(_gameActorFeatures[i] as IGameActorFeature);
            }
            for (int i = 0; i < gameActorFeatures.Count; i++)
            {
                gameActorFeatures[i].DoInit(this);
            }
        }

        protected override void DoUpdate()
        {
            int c = gameActorFeatures.Count;
            _time += Time.deltaTime;
            for (int i = 0; i < c; i++)
            {
                gameActorFeatures[i].DoUpdate(this, _time);
            }
        }
        protected override void DoFixedUpdate()
        {
            int c = gameActorFeatures.Count;
            for (int i = 0; i < c; i++)
            {
                gameActorFeatures[i].DoFixedUpdate(this, _time);
            }
        }
        public bool GetFeature<T>(out T result) where T : IGameActorFeature
        {
            foreach (var feature in gameActorFeatures)
            {
                if (feature is T cFeature)
                {
                    result = cFeature;
                    return true;
                }
            }

            result = default;
            return false;
        }

        protected override void DoOnDestroyed()
        {
            _onGameActorDestroyedEvt.TriggerEvent(this);
        }
    }
}
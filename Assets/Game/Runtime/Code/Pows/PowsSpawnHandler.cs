using System.Collections.Generic;
using com.fscigliano.AsyncPoolingSystem;
using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.CommonExtensions;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Pows
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Manages power-up spawning by detecting collisions and spawning random power-ups
    ///                  at minimum time intervals.
    /// Changelog:       
    /// </summary>
    public class PowsSpawnHandler : DestroyHandlerBase
    {
        [System.Serializable]
        public class PowChanceData
        {
            public GameActorIDAsset powId;
            public float chance = 1;
        }
        [SerializeField] protected float _powTime = 5f;
        [SerializeField] protected AsyncPoolManager _multiPool;
        [SerializeField] protected List<PowChanceData> _powChanceData = new ();
        private readonly Dictionary<GameActorIDAsset, float> _powerUpsChanceDictionary = new Dictionary<GameActorIDAsset, float>();

        private float lastPowTime = 0;
        protected override void HandleOnEnable()
        {
            _powerUpsChanceDictionary.Clear();
            for (int i = 0; i < _powChanceData.Count; i++)
            {
                _powerUpsChanceDictionary.Add(_powChanceData[i].powId, _powChanceData[i].chance);
            }
        }

        protected override void HandleExplosion(GameActor obj, IDAsset vfxId)
        {
            if (Time.time >= lastPowTime + _powTime)
            {
                var powId = _powerUpsChanceDictionary.RandomElementByWeight(e => e.Value).Key;
                if (powId != null)
                {
                    lastPowTime = Time.time;
                    SpawnPow(powId, obj);
                }
            }
        }

        private void SpawnPow(GameActorIDAsset powId, GameActor obj)
        {
            _multiPool.Spawn(powId, obj.transform.position, Quaternion.identity);
        }
    }
}
using System.Collections.Generic;
using com.fscigliano.CommonExtensions;
using com.fscigliano.VerticalShootEmUp.Events.Custom;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Core
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     This listens for collision events and filter them according to the list of gameActors.
    /// Changelog:       
    /// </summary>
    public abstract class DestroyHandlerBase : MonoBehaviour
    {
        [SerializeField] protected GameActorEvt _explodedEvt;
        [SerializeField] protected List<GameActorIDAsset> _explodingGameActors = new ();
        [SerializeField] protected IDAsset _vfxId;
        
        private void OnEnable()
        {
            _explodedEvt.AddListener(OnExplosion);
            HandleOnEnable();
        }

        protected virtual void HandleOnEnable()
        {
            
        }
        private void OnExplosion(GameActor obj)
        {
            if (!_explodingGameActors.Contains(obj.Id)) return;
            HandleExplosion(obj, _vfxId);
        }

        protected abstract void HandleExplosion(GameActor obj, IDAsset vfxId);
        
        // Update is called once per frame
        private void OnDisable()
        {
            _explodedEvt.RemoveListener(OnExplosion);
        }
    }
}
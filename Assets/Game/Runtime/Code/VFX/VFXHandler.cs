using com.fscigliano.AsyncPoolingSystem;
using com.fscigliano.CommonExtensions;
using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.VFX
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Manages collision visual effects by listening to events and filtering based on
    ///                  GameActor IDs to determine which collisions spawn effects.
    /// Changelog:       
    /// </summary>
    public class VFXHandler : DestroyHandlerBase
    {
        [SerializeField] protected AsyncPoolManager _pool;
        protected override void HandleExplosion(GameActor obj, IDAsset vfxId)
        {
            _pool.Spawn(vfxId, obj.transform.position, Quaternion.identity);
        }
    }
}
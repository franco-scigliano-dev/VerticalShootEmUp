using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     ScriptableObject implementation of IGameActorPhysics, just to show the power of the
    ///                  interface based adapter pattern.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(GameActorPhysicsAsset), fileName = nameof(GameActorPhysicsAsset))]
    public class GameActorPhysicsAsset : ScriptableObject, IGameActorPhysics
    {
        [SerializeField] protected float _acceleration;
        public float Acceleration => _acceleration;
    }
}
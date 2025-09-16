using com.fscigliano.CommonExtensions;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActors
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Identifier asset for GameActors that maintains equality across instances.
    ///                  Works with Addressables without ScriptableObject instantiation issues.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(GameActorIDAsset), fileName = nameof(GameActorIDAsset))]
    public class GameActorIDAsset : IDAsset
    {
    }
}
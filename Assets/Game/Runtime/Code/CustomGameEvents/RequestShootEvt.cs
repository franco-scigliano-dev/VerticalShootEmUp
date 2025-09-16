using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.VerticalShootEmUp.Weapons;
using com.fscigliano.GameEvents;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Events.Custom
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(RequestShootEvt), fileName = nameof(RequestShootEvt))]
    public class RequestShootEvt : GameEvent2<GameActor, WeaponData>
    {

    }
}
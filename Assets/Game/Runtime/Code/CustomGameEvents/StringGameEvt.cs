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
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(StringGameEvt), fileName = nameof(StringGameEvt))]
    public class StringGameEvt : GameEvent1<string>
    {

    }
}
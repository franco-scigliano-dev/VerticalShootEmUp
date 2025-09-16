using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.GameEvents;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Events.Custom
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Custom game event that triggers with a GameActor parameter.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(GameActorEvt), fileName = nameof(GameActorEvt))]
    public class GameActorEvt : GameEvent1<GameActor>
    {

    }
}
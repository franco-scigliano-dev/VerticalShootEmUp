using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.GameEvents;
using UnityEngine.Events;

namespace com.fscigliano.VerticalShootEmUp.Events.Custom
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Event listener that responds to GameActorEvt events with UnityEvent callbacks.
    /// Changelog:       
    /// </summary>
    public class GameActorEvtListener : GameEvent1Listener<GameActor, GameActorEvt, GameActorEvtListener.UEvt>
    {
        [System.Serializable]
        public class UEvt:UnityEvent<GameActor>{}
    }
}
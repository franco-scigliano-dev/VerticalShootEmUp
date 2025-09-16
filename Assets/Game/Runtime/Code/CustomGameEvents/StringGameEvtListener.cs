using com.fscigliano.GameEvents;
using UnityEngine.Events;

namespace com.fscigliano.VerticalShootEmUp.Events.Custom
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     
    /// Changelog:       
    /// </summary>
    public class StringGameEvtListener : GameEvent1Listener<string, StringGameEvt, StringGameEvtListener.UEvt>
    {
        [System.Serializable]
        public class UEvt:UnityEvent<string>{}
    }
}
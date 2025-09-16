using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActors
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Input interface that objects implement to be used as input for the movement feature.
    /// Changelog:       
    /// </summary>
    public interface IInputProvider
    {
        Vector2 Intention { get; set; }
        bool Attack { get; set; }
    }
}
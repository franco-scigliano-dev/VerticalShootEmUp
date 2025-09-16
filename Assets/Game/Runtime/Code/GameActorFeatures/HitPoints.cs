using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Hitpoints version that saves the hitpoints in itself as a component.
    /// Changelog:       
    /// </summary>
    public class HitPoints : HitPointsBase
    {
        [SerializeField] protected int _health;
        [SerializeField] protected int _baseHealth;
        protected override int BaseHealth => _baseHealth;

        protected override int Health
        {
            get => _health;
            set => _health = value;
        }
    }
}
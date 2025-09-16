using com.fscigliano.VerticalShootEmUp.Levels;
using com.fscigliano.GameEvents;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Manages avatar-specific damage and health, saving data to CurrentLevelDataAsset state.
    /// Changelog:       
    /// </summary>
    public class AvatarHitPoints : HitPointsBase
    {
        [SerializeField] protected GameEvent _avatarHealthChangedEvt;
        [SerializeField] protected CurrentLevelDataAsset _currentLevelData;
        [SerializeField] protected int _baseHealth;
        protected override int BaseHealth => _baseHealth;

        protected override int Health
        {
            get => _currentLevelData.AvatarHealth;
            set => _currentLevelData.SetAvatarHealth(value);
        }

        protected override void HandleHealthChanged()
        {
            if (Health == 0)
            {
                int lives = _currentLevelData.CurrentLives;
                _currentLevelData.SetCurrentLives(--lives);
            }
            _avatarHealthChangedEvt.TriggerEvent();
        }


    }
}

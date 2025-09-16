using com.fscigliano.VerticalShootEmUp.Levels;
using com.fscigliano.GameEvents;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;
using UnityEngine.UI;

namespace com.fscigliano.VerticalShootEmUp.UI
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Updates the player's health bar UI by listening to health refresh events.
    /// Changelog:       
    /// </summary>
    public class AvatarHealthBarUI : MonoBehaviour
    {
        [SerializeField] protected GameConfigAsset _gameConfig;
        [SerializeField] protected CurrentLevelDataAsset _currentLvlData;
        [SerializeField] protected GameEvent _avatarHealthChangedEvt;
        [SerializeField] protected Image _healthBarImg;
        [SerializeField] protected float _ratioToBlink = 0.5f;
        [SerializeField] protected float _blinkTime = 0.1f;
        protected float ratio = 1;
        protected float lastBlinkTime;
        private void OnEnable()
        {
            _avatarHealthChangedEvt.AddListener(HandleAvatarHealthChanged);
        }

        private void HandleAvatarHealthChanged()
        {
            ratio = (float) _currentLvlData.AvatarHealth / (float)_gameConfig.AvatarMaxHealth;
            _healthBarImg.fillAmount = ratio;
        }

        private void Update()
        {
            if (ratio < _ratioToBlink)
            {
                float t = Time.realtimeSinceStartup;
                if (t >= lastBlinkTime + _blinkTime)
                {
                    lastBlinkTime = t;
                    _healthBarImg.enabled = !_healthBarImg.enabled;
                }
            }
            else if (!_healthBarImg.enabled)
            {
                _healthBarImg.enabled = true;
            }
        }

        private void OnDisable()
        {
            _avatarHealthChangedEvt.RemoveListener(HandleAvatarHealthChanged);
        }
    }
}
using com.fscigliano.VerticalShootEmUp.Events.Custom;
using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.VerticalShootEmUp.Levels;
using com.fscigliano.GameEvents;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Score
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Manages score calculation by detecting GameActor destruction and adding configured
    ///                  score values to the current level data.
    /// Changelog:       
    /// </summary>
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] protected GameConfigAsset _config;
        [SerializeField] protected UserDataAsset _userData;
        [SerializeField] protected CurrentLevelDataAsset _lvlDataAsset;
        [SerializeField] protected GameActorEvt _onGameActorDestroyedEvt;
        [SerializeField] protected GameEvent _refreshScoreEvt;
        private void OnEnable()
        {
            _onGameActorDestroyedEvt.AddListener(HandleActorDestroyed);
        }

        private void HandleActorDestroyed(GameActor obj)
        {
            if (!_config.HasScore(obj.Id)) return;
            
            var sd = _config.GetScoreData(obj.Id);
            _lvlDataAsset.AddScore(sd.score);
            if (_userData.highscore < _lvlDataAsset.Score)
            {
                _userData.highscore = _lvlDataAsset.Score;
            }
            _refreshScoreEvt.TriggerEvent();
        }

        private void OnDisable()
        {
            _onGameActorDestroyedEvt.RemoveListener(HandleActorDestroyed);
        }
    }
}
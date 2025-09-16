using com.fscigliano.VerticalShootEmUp.Levels;
using com.fscigliano.GameEvents;
using UnityEngine;
using UnityEngine.UI;

namespace com.fscigliano.VerticalShootEmUp.UI
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Updates the score text in the gameplay and title screen hud.
    /// Changelog:       
    /// </summary>
    public class ScoreTextUpdater : MonoBehaviour
    {
        [SerializeField] protected CurrentLevelDataAsset _levelData;
        [SerializeField] protected GameEvent _refreshScoreEvt;
        [SerializeField] protected string _scoreText;
        [SerializeField] protected Text _scoreTextField;
        private void OnEnable()
        {
            _refreshScoreEvt.AddListener(HandleScoreUpdate);
            HandleScoreUpdate();
        }

        private void HandleScoreUpdate()
        {
            _scoreTextField.text = _scoreText.Replace("{0}", _levelData.Score.ToString());
        }

        private void OnDisable()
        {
            _refreshScoreEvt.RemoveListener(HandleScoreUpdate);
        }
    }
}
using com.fscigliano.GameEvents;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;
using UnityEngine.UI;

namespace com.fscigliano.VerticalShootEmUp.UI
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Updates the high score text in the gameplay and title screen hud.
    /// Changelog:       
    /// </summary>
    public class HighscoreTextUpdater : MonoBehaviour
    {
        [SerializeField] protected UserDataAsset _userData;
        [SerializeField] protected GameEvent _refreshScoreEvt;
        [SerializeField] protected string _highScoreText;
        [SerializeField] protected Text _highScoreTextField;
        private void OnEnable()
        {
            _refreshScoreEvt.AddListener(HandleScoreUpdate);
            HandleScoreUpdate();
        }

        private void HandleScoreUpdate()
        {
            _highScoreTextField.text = _highScoreText.Replace("{0}", _userData.highscore.ToString());
        }

        private void OnDisable()
        {
            _refreshScoreEvt.RemoveListener(HandleScoreUpdate);
        }
    }
}
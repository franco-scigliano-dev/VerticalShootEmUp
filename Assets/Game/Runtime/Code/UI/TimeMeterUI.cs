using com.fscigliano.VerticalShootEmUp.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace com.fscigliano.VerticalShootEmUp.UI
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Updates the time meter in TimeAttack game mode, or disables it in other modes.
    /// Changelog:       
    /// </summary>
    public class TimeMeterUI : MonoBehaviour
    {
        [SerializeField] protected CurrentLevelDataAsset _currentLevelData;
        [SerializeField] protected Text _timeText;

        public void CheckIfUsed()
        {
            if (_currentLevelData.CurrentLevel!= null && _currentLevelData.CurrentLevel.gameMode != GameMode.TIME)
            {
                gameObject.SetActive(false);
            }
        }
        public void HandleTimeUpdate()
        {
            if (isActiveAndEnabled)
                _timeText.text = Mathf.Max(0, Mathf.FloorToInt(_currentLevelData.GetTimeAttackCurrentTime)).ToString();
        }
    }
}

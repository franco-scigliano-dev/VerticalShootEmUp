using com.fscigliano.VerticalShootEmUp.Levels;
using com.fscigliano.GameEvents;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.UI
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Listens to RefreshHudEvt event to check the lives of the player and update the hud if needed.
    /// Changelog:       
    /// </summary>
    public class LivesMeterUI : MonoBehaviour
    {
        [SerializeField] protected CurrentLevelDataAsset _currentLevelData;
        [SerializeField] protected GameObject[] _liveObjs = new GameObject[3];
        [SerializeField] protected GameEvent _refreshHudEvt;
        private void OnEnable()
        {
            _refreshHudEvt.AddListener(HandleRefreshHud);
        }

        private void HandleRefreshHud()
        {
            int lives = _currentLevelData.CurrentLives;
            for (int i = 0; i < _liveObjs.Length; i++)
            {
                _liveObjs[i].SetActive(i<lives);
            }
        }

        private void OnDisable()
        {
            _refreshHudEvt.RemoveListener(HandleRefreshHud);
        }
    }
}

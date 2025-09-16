using System.Collections.Generic;
using com.fscigliano.VerticalShootEmUp.Levels;
using com.fscigliano.SequentialEvents;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

namespace com.fscigliano.VerticalShootEmUp.ScenesFlow
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Manages level setup and loads the gameplay scene using a timed sequence.
    /// Changelog:       
    /// </summary>
    public class GameplayLevelLoader : MonoBehaviour
    {
        [SerializeField] protected List<AssetReference> _levels = new List<AssetReference>();
        [SerializeField] protected CurrentLevelDataAsset _currentLevelData;
        [SerializeField] protected EventSystem _eventSystem;
        [SerializeField] protected SequenceComponent _sequence;

        public void LoadGameplayLevel(int i)
        {
            _eventSystem.enabled = false;
            var a = _levels[i].LoadAssetAsync<LevelAsset>();
            _currentLevelData.LoadLevelHandle = a;
            a.Completed += handle =>
            {
                _currentLevelData.SetLevel(a.Result);
                _sequence.sequence.Run();
            };
        }
    }
}
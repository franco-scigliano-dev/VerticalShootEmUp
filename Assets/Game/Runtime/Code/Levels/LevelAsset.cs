using System.Collections.Generic;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace com.fscigliano.VerticalShootEmUp.Levels
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     A static data scriptableObject that holds the level configuration.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(LevelAsset), fileName = nameof(LevelAsset))]
    public class LevelAsset : ScriptableObject
    {
        [SerializeField] protected GameMode _gameMode;
        [SerializeField] protected Color _cameraFillColor;
        [SerializeField] protected AssetReferenceGameObject _backgroundPrefab;
        [SerializeField] protected List<LevelStepData> _levelDatas = new List<LevelStepData>();
        [SerializeField] protected float _time = 60;
        public float Time => _time;

        public GameMode gameMode => _gameMode;

        public Color cameraFillColor => _cameraFillColor;

        public int StepsCount => _levelDatas.Count;

        public AssetReferenceGameObject backgroundPrefab => _backgroundPrefab;
        public LevelStepData GetStep(int idx)
        {
            return _levelDatas[idx];
        }
    }
}
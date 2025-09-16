using System.Collections.Generic;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Core
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Main static game data structure. This data is meant to be static, so it's
    ///                  not be made to be modified in runtime.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(GameConfigAsset), fileName = nameof(GameConfigAsset))]
    public class GameConfigAsset : ScriptableObject
    {
        [SerializeField] private List<ScoreData> _scoreDatas  = new List<ScoreData>();
        [SerializeField] private int _avatarMaxHealth = 100;

        [SerializeField] private int _avatarRespawnTime = 2;
        [SerializeField] private float _avatarInvulnerabilityTime = 3;
        [SerializeField] private int _startLives = 3;
        [SerializeField] private bool _mockLoadingTimes = false;
        
        public int StartLives => _startLives;
        public int AvatarRespawnTime=>_avatarRespawnTime;
        public float AvatarMaxHealth => _avatarMaxHealth;

        public float AvatarInvulnerabilityTime => _avatarInvulnerabilityTime;

        public bool MockLoadingTimes => _mockLoadingTimes;
        
        private Dictionary<GameActorIDAsset, ScoreData> _scoreDataById = new Dictionary<GameActorIDAsset, ScoreData>();
        private bool cached = false;

        public bool HasScore(GameActorIDAsset objId)
        {
            Cache();
            return _scoreDataById.ContainsKey(objId);
        }

        public ScoreData GetScoreData(GameActorIDAsset objId)
        {
            Cache();
            return _scoreDataById[objId];
        }

        private void Cache()
        {
            if (!cached)
            {
                _scoreDataById.Clear();
                cached = true;
                foreach (var s in _scoreDatas)
                {
                    _scoreDataById.Add(s.id, s);
                }
            }
        }

        public void ResetValues()
        {
            _scoreDataById.Clear();
            cached = false;
        }
    }
}
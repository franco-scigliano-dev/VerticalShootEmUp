using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using com.fscigliano.AsyncPoolingSystem;
using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.Events.Custom;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace com.fscigliano.VerticalShootEmUp.Levels
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     The main gameplay system that loads and initialize the required pools and then uses the
    ///                  current LevelAsset data to create waves of enemies. Also, it manages the avatar
    ///                  state and respawn.
    /// Changelog:       
    /// </summary>
    public class LevelHandler : MonoBehaviour
    {
        [System.Serializable]
        public class StringUnityEvent : UnityEvent<string>
        {
            
        }

        [System.Serializable]
        public class GameModeData
        {
            public GameMode type;
            public GameModeBase mode;
        }
        [Header("Scene References"), SerializeField] protected Camera _mainCamera;
        [SerializeField] protected List<GameModeData> _gameModes = new List<GameModeData>();
        
        [Header("Asset References"), SerializeField] protected UserDataAsset _userData;
        [SerializeField] protected LevelAsset _levelAsset;
        [SerializeField] protected CurrentLevelDataAsset _currentLevelData;
        [SerializeField] protected GameActorIDAsset _avatarId;
        [SerializeField] protected GameActorIDAsset _bossId;
        [SerializeField] protected AsyncPoolManager _asyncPoolingSystem;
        
        [SerializeField] protected Transform _avatarSpawn;

        [Header("Events"), SerializeField] protected GameActorEvt _gameActorDestroyedEvt;
        [SerializeField] protected UnityEvent _OnLevelLoadedUEvt;
        [SerializeField] protected UnityEvent _gameOverUEvt;
        [SerializeField] protected UnityEvent _onEndLevelUEvt;
        [SerializeField] protected StringUnityEvent _showTextUEvt;
        [SerializeField] protected GameConfigAsset _gameConfig;

        private GameObject backgroundInstance;
        private AsyncOperationHandle<GameObject> backgroundHandle;
        private GameModeBase gameModeHandler;
        private void OnEnable()
        {
            _gameActorDestroyedEvt.AddListener(HandleGameActorDestroyed);
        }

        private void OnDisable()
        {
            _gameActorDestroyedEvt.RemoveListener(HandleGameActorDestroyed);
        }

        private void HandleGameActorDestroyed(GameActor obj)
        {
            if (obj.Id == _avatarId)
            {
                HandleAvatarDestroyed();
            }

            if (obj.Id == _bossId)
            {
                HandleBossDestroyed();
            }
        }

        private void HandleBossDestroyed()
        {
            gameModeHandler.FinishLevel();
        }

        private void HandleAvatarDestroyed()
        {
            if (_currentLevelData.CurrentLives > 0)
            {
                StartCoroutine(DoRespawnAvatar(_gameConfig.AvatarRespawnTime));
            }
            else
            {
                _gameOverUEvt.Invoke();
            }
        }
        private IEnumerator DoRespawnAvatar(int i)
        {
            yield return new WaitForSeconds(i);
            SpawnAvatar();
        }

        public void LevelInit()
        {
            if (_currentLevelData.CurrentLevel != null)
            {
                _levelAsset = _currentLevelData.CurrentLevel;
            }
            else
            {
                _currentLevelData.SetLevel(_levelAsset);
            }
            _currentLevelData.ResetGameplayData();

            gameModeHandler = GetGameMode(_levelAsset.gameMode);
            if (gameModeHandler == null)
            {
                Debug.LogError("Game mode not defined.");
            }
            gameModeHandler.Init(this, _levelAsset);
            StartCoroutine(ExecuteLevelFlow());
        }

        private GameModeBase GetGameMode(GameMode mode)
        {
            for (int i = 0; i < _gameModes.Count; i++)
            {
                if (_gameModes[i].type == mode)
                    return _gameModes[i].mode;
            }
            return null;
        }

        private IEnumerator ExecuteLevelFlow()
        {
            yield return StartCoroutine(ExecuteLoadLevel());
            yield return StartCoroutine(gameModeHandler.ExecuteLevel());
        }

        private IEnumerator ExecuteLoadLevel()
        {
            _mainCamera.backgroundColor = _levelAsset.cameraFillColor;

            if (_gameConfig.MockLoadingTimes)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 2f));
            }
            // spawn background
            backgroundHandle = _levelAsset.backgroundPrefab.LoadAssetAsync<GameObject>();
            backgroundHandle.Completed+= handle =>
            {
                backgroundInstance = Instantiate(handle.Result);
                backgroundInstance.gameObject.SetActive(true);
            };
            yield return backgroundHandle;
            
            // instantiate avatar

            SpawnAvatar();
            
            _OnLevelLoadedUEvt.Invoke();
        }

        private void SpawnAvatar()
        {
            var a = _currentLevelData.GetAvatar();
            
            if (a == null || !a.isActiveAndEnabled)
            {
                var o = _asyncPoolingSystem.Spawn(_avatarId, _avatarSpawn.position, Quaternion.identity);
                o.gameObject.SetActive(true);
                _currentLevelData.SetAvatar(o as GameActor);
            }
        }


        public void SpawnGameActor(LevelStepData data)
        {
            var actor = _asyncPoolingSystem.Spawn(data.enemyId,
                _asyncPoolingSystem.transform.position + (Vector3)data.spawnOffset, Quaternion.identity);
        }

        private void OnDestroy()
        {
            if (backgroundHandle.IsValid() && backgroundHandle.Status != AsyncOperationStatus.None)
            {
                Addressables.Release(backgroundHandle);
            }
            _currentLevelData.ExitGameplay();
        }

        public void FinishLevel()
        {
            if (_currentLevelData.CurrentLives > 0 || _currentLevelData.GetAvatar().isActiveAndEnabled)
            {
                _userData.Save();
                _onEndLevelUEvt.Invoke();
            }
        }
        protected void Update()
        {
            _currentLevelData.CurrentTime += Time.deltaTime;
        }
        
        public void ShowTextUEvt(string dataText)
        {
            _showTextUEvt.Invoke(dataText);
        }

        public void SetCurrentLives(int lives)
        {
            _currentLevelData.SetCurrentLives(lives);
        }
    }
}
using System.Collections;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Levels
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     
    /// Changelog:       
    /// </summary>
    public abstract class GameModeBase : MonoBehaviour
    {
        [SerializeField] protected CurrentLevelDataAsset _currentLevelData;
        protected LevelHandler lvlHandler;
        protected LevelAsset lvlAsset;
        protected bool levelFinished = false;
        
        public void Init(LevelHandler lvlHandler, LevelAsset lvlAsset)
        {
            this.lvlHandler = lvlHandler;
            this.lvlAsset = lvlAsset;
            HandleInit();
        }

        protected virtual void HandleInit()
        {
            
        }
        public abstract IEnumerator ExecuteLevel();


        protected void SpawnWave(LevelStepData data)
        {
            StartCoroutine(DoSpawnWave(data));
        }
        protected IEnumerator DoSpawnWave(LevelStepData data)
        {
            int waveCount = data.waveCount;
            float targetTime = _currentLevelData.CurrentTime + data.betweenTime;
            do
            {
                lvlHandler.SpawnGameActor(data);

                waveCount--;
                do
                {
                    yield return null;
                } while (_currentLevelData.CurrentTime < targetTime);

                targetTime += data.betweenTime;
            } while (waveCount > 0 && !levelFinished);
        }

        public void FinishLevel()
        {
            levelFinished = true;
        }
    }
}
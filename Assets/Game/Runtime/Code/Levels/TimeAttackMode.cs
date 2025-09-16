using System.Collections;
using System.Collections.Generic;
using com.fscigliano.GameEvents;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Levels
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     This mode is limited by time instead of following the steps linearly. it
    ///                  shuffles the wave steps and spawn them randomly.
    /// Changelog:       
    /// </summary>
    public class TimeAttackMode: GameModeBase
    {
        [SerializeField] protected GameEvent _refreshTimeEvt;
        private Coroutine timeRefreshCoroutine;

        protected override void HandleInit()
        {
            lvlHandler.SetCurrentLives(0);
            _refreshTimeEvt.TriggerEvent();
        }
        
        public override IEnumerator ExecuteLevel()
        {
            levelFinished = false;
            timeRefreshCoroutine = StartCoroutine(HandleRefreshTime());
            LevelStepData data;

            // start spawning level waves
            float targetTime = _currentLevelData.CurrentTime;
            List<LevelStepData> waveSteps = GetSteps(lvlAsset);

            do
            {
                data = waveSteps[UnityEngine.Random.Range(0, waveSteps.Count)];
                targetTime += data.timeBefore;
                do
                {
                    yield return null;
                    if (levelFinished)
                        break;
                } while (_currentLevelData.CurrentTime < targetTime);

                if (!levelFinished)
                    SpawnWave(data);
                
            } while (!levelFinished);

            StopTimeCoroutine();

            lvlHandler.FinishLevel();
        }

        private IEnumerator HandleRefreshTime()
        {
            do
            {
                if (_currentLevelData.GetTimeAttackCurrentTime <= 0)
                {
                    levelFinished = true;
                }
                yield return new WaitForSeconds(0.25f);
                _refreshTimeEvt.TriggerEvent();
            } while (true);
        }

        private void StopTimeCoroutine()
        {
            if (timeRefreshCoroutine != null)
            {
                StopCoroutine(timeRefreshCoroutine);
                timeRefreshCoroutine = null;
            }
        }
        private List<LevelStepData> GetSteps(LevelAsset levelAsset)
        {
            List<LevelStepData> result = new List<LevelStepData>();
            for (int i = 0; i < levelAsset.StepsCount; i++)
            {
                var d = levelAsset.GetStep(i);
                if (d.enabled && d.type == LevelStepType.WAVE)
                {
                    result.Add(d);
                }
            }
            return result;
        }

        private void OnDisable()
        {
            StopTimeCoroutine();
        }
    }
}
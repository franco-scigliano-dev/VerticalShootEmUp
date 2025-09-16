using System;
using System.Collections;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Levels
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Arcade game mode that reads level data sequentially and executes level steps based on timing.
    /// Changelog:       
    /// </summary>
    public class ArcadeMode: GameModeBase
    {
        [SerializeField] protected GameConfigAsset _config;
        private int _currentStepIdx = 0;
        protected override void HandleInit()
        {
            lvlHandler.SetCurrentLives(_config.StartLives);
        }

        public override IEnumerator ExecuteLevel()
        {
            LevelStepData data;
            // start spawning level waves
            float targetTime = _currentLevelData.CurrentTime ;
            _currentStepIdx = -1;
            GoNextStep();
            levelFinished = false;
            do
            {
                data = lvlAsset.GetStep(_currentStepIdx);
                targetTime += data.timeBefore;
                do
                {
                    yield return null;
                    if (levelFinished)
                        break;
                } while (_currentLevelData.CurrentTime < targetTime);

                switch (data.type)
                {
                    case LevelStepType.WAVE:
                        SpawnWave(data);
                        break;
                    case LevelStepType.END_LEVEL:
                        levelFinished = true;
                        break;
                    case LevelStepType.SHOW_TEXT:
                        lvlHandler.ShowTextUEvt(data.text);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                GoNextStep();
            } while (_currentStepIdx < lvlAsset.StepsCount && !levelFinished);

            lvlHandler.FinishLevel();

        }
        private void GoNextStep()
        {
            int oldStep = _currentStepIdx;
            
            bool enabled = false;
            int steps = lvlAsset.StepsCount;
            do
            {
                _currentStepIdx++;
                steps--;
                if (!enabled && _currentStepIdx == lvlAsset.StepsCount)
                {
                    _currentStepIdx = 0;
                }
                enabled = lvlAsset.GetStep(_currentStepIdx).enabled;
            } while (!enabled && steps >0);
            
            if (!enabled)
            {
                _currentStepIdx = oldStep;
            }
        }
    }
    
}
using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace com.fscigliano.VerticalShootEmUp.Levels
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Monostate ScriptableObject used to manage the runtime data for a level.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(CurrentLevelDataAsset), fileName = nameof(CurrentLevelDataAsset))]
    public class CurrentLevelDataAsset : ScriptableObject
    {
        private static GameActor currentAvatar;
        private static int score;
        private static LevelAsset level;
        private static int avatarHealth;
        private static int currentLives;
        private static float currentTime;
        
        public LevelAsset CurrentLevel => level;
        
        public int CurrentLives => currentLives;
        public int AvatarHealth => avatarHealth;
        
        public void SetAvatar(GameActor avatar)
        {
            currentAvatar = avatar;
        }

        public GameActor GetAvatar()
        {
            return currentAvatar;
        }
        public int Score
        {
            get => score;
        }
        public void AddScore(int s)
        {
            score += s;
        }
        public void ResetValues()
        {
            ResetGameplayData();
            level = null;
        }

        public void SetLevel(LevelAsset l)
        {
            level = l;
        }

        public void SetAvatarHealth(int h)
        {
            avatarHealth = h;
        }

        public void SetCurrentLives(int v)
        {
            currentLives = v;
        }

        public void ResetGameplayData()
        {
            currentAvatar = null;
            score = 0;
            currentTime = 0;
        }

        public void ExitGameplay()
        {
            if (LoadLevelHandle.IsValid() && LoadLevelHandle.Status != AsyncOperationStatus.None)
            {
                Addressables.Release(LoadLevelHandle);
            }
        }

        public AsyncOperationHandle LoadLevelHandle { get; set; }

        public float CurrentTime
        {
            get => currentTime;
            set => currentTime = value;
        }

        public float GetTimeAttackCurrentTime
        {
            get
            {
                return (CurrentLevel.Time - CurrentTime);
            }
        }
    }
}
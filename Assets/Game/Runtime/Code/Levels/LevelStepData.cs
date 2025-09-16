using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Levels
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Data used in LevelAssetData. This holds a Step on the level, that according to the selected
    ///                  LevelStepType, it shows the required properties to fill, by using a custom PropertyDrawer.
    ///                  With little additional work, this could be modified to be json serialization friendly and be
    ///                  updated from a server.
    /// Changelog:       
    /// </summary>
    [System.Serializable]
    public class LevelStepData
    {
        public LevelStepType type;
        public bool enabled = true;
        public float timeBefore = 1;
        public int waveCount;
        public GameActorIDAsset enemyId;
        public Vector2 spawnOffset;
        public float betweenTime = 0.5f;
        [TextArea] public string text;
    }
}
using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.VerticalShootEmUp.Levels;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     
    /// Changelog:       
    /// </summary>
    public class KamikazeInput : GameActorFeatureBase, IInputProvider
    {
        private const float minRatioDirectionTime = 0.3f;
        private const float maxRatioDirectionTime = 0.4f;
        
        [SerializeField] protected CurrentLevelDataAsset _levelData;
        [SerializeField] protected float _totalDuration;

        private GameActor tempAvatar;
        private Vector2 intention;
        private float changeDirectionTime;
        private bool changingDirection = false;
        
        public Vector2 Intention
        {
            get => intention;
            set => intention = value;
        }

        public bool Attack { get; set; }

        private void OnEnable()
        {
            ResetValues();
        }

        private void ResetValues()
        {
            changingDirection = false;
            changeDirectionTime = UnityEngine.Random.Range(_totalDuration * minRatioDirectionTime,
                _totalDuration * maxRatioDirectionTime);
            intention.x = 0;
            intention.y = -1;
        }
        public override void DoUpdate(GameActor a, float t)
        {
            if (t < changeDirectionTime)
            {
                intention.x = 0;
                intention.y = -1;
            }
            else if (!changingDirection)
            {
                tempAvatar = _levelData.GetAvatar();
                if (tempAvatar != null)
                {
                    changingDirection = true;
                    var dir = tempAvatar.transform.position - transform.position;
                    intention = dir.normalized;
                }
            }
        }
    }
}
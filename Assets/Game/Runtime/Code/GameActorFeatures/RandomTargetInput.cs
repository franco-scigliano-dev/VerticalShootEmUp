using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     
    /// Changelog:       
    /// </summary>
    public class RandomTargetInput : GameActorFeatureBase, IInputProvider
    {
        [SerializeField] protected float _totalDuration;
        
        private Vector2 intention;
        private float changeDirectionTime;
        private float changeDirectionEndTime;
        private bool changingDirection = false;
        
        public Vector2 Intention
        {
            get => intention;
            set => intention = value;
        }

        public bool Attack { get; set; }


        private const float minRatioDirectionTime = 0.3f;
        private const float maxRatioDirectionTime = 0.4f;
        private const float minRatioDirectionEndTime = 0.1f;
        private const float maxRatioDirectionEndTime = 0.2f;

        private void OnEnable()
        {
            ResetValues();
        }

        private void ResetValues()
        {
            changingDirection = false;
            changeDirectionTime = UnityEngine.Random.Range(_totalDuration * minRatioDirectionTime,
                _totalDuration * maxRatioDirectionTime);
            changeDirectionEndTime = changeDirectionTime + UnityEngine.Random.Range(_totalDuration * minRatioDirectionEndTime,
                _totalDuration * maxRatioDirectionEndTime);
            intention.x = 0;
            intention.y = -1;
        }

        public override void DoUpdate(GameActor a, float t)
        {
            if (t < changeDirectionTime || t > changeDirectionEndTime)
            {
                intention.x = 0;
                intention.y = -1;
            }
            else if (!changingDirection)
            {
                changingDirection = true;
                intention.x = UnityEngine.Random.value < 0.5f ? -1 : 1;
                intention.y = -intention.y;
            }
        }
    }
}
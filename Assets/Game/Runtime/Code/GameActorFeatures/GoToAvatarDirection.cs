using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.VerticalShootEmUp.Levels;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     This modifies the intention provided to point to the avatar or it's last location,
    ///                  when the object is enabled.
    /// Changelog:       
    /// </summary>
    public class GoToAvatarDirection : MonoBehaviour, IGameActorFeature, IInputProvider, IGameActorPhysics
    {
        [SerializeField] protected CurrentLevelDataAsset _levelData;
        [SerializeField] protected float _acceleration = 1;
        
        private GameActor tempAvatar;
        private Vector2 intention;

        void OnEnable()
        {
            tempAvatar = _levelData.GetAvatar();
            if (tempAvatar != null)
            {
                var dir = tempAvatar.transform.position - transform.position;
                intention = dir.normalized;
            }
        }

        public Vector2 Intention
        {
            get => intention;
            set => intention = value;
        }
        public bool Attack { get; set; }

        public float Acceleration
        {
            get => _acceleration;
        }

        public void DoInit(GameActor a)
        {
            
        }

        public void DoUpdate(GameActor a, float t)
        {

        }

        public void DoFixedUpdate(GameActor a, float t)
        {

        }
    }
}
using com.fscigliano.VerticalShootEmUp.Events.Custom;
using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.VerticalShootEmUp.Weapons;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorHelpers
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     This is used by enemies to shoot randomly.
    /// Changelog:       
    /// </summary>
    public class EnemyRandomShoot : MonoBehaviour, IInputProvider
    {
        [SerializeField] protected GameActor _gameActor;
        [SerializeField] protected RequestShootEvt _requestShootEvt;
        [SerializeField] protected float _fireChange = 0.1f;
        [SerializeField] protected int _shoots = 2;
        private bool attack;
        private int shoots = 2;

        public Vector2 Intention { get; set; }

        public bool Attack
        {
            get => attack;
            set => attack = value;
        }

        private void OnEnable()
        {
            attack = false;
            shoots = _shoots;
            _requestShootEvt.AddListener(HandleShoot);
        }

        private void OnDisable()
        {
            _requestShootEvt.RemoveListener(HandleShoot);
        }

        private void HandleShoot(GameActor arg1, WeaponData arg2)
        {
            if (arg1 == _gameActor)
            {
                shoots--;
            }
        }

        private void Update()
        {
            if (shoots > 0 && !attack && UnityEngine.Random.value < _fireChange)
            {
                attack = true;
            }
        }
    }
}
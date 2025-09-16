using com.fscigliano.VerticalShootEmUp.Events.Custom;
using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.VerticalShootEmUp.Weapons;
using com.fscigliano.PropertyDrawersCollection;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     
    /// Changelog:       
    /// </summary>
    public class WeaponShooter : GameActorFeatureBase
    {
        [SerializeField] protected RequestShootEvt _requestShootEvt;
        
        [SerializeField, ObjectType(typeof(IInputProvider))]
        protected UnityEngine.Object _inputProvider;

        [SerializeField] protected WeaponDataAsset _currentWeapon;
        protected WeaponDataAsset overrideWeapon;
        
        private IInputProvider inputProvider;

        private float lastShootTime;
        private float currentCooldown;
        private int currentWeaponIdx;

        public WeaponDataAsset currentWeapon
        {
            get => overrideWeapon!=null?overrideWeapon:_currentWeapon;
        }

        private void OnEnable()
        {
            overrideWeapon = null;
            ResetWeapon();
            lastShootTime = -currentCooldown;
        }

        protected override void HandleDoInit(GameActor gameActor)
        {
            inputProvider = _inputProvider as IInputProvider;
            ResetWeapon();
        }

        private void ResetWeapon()
        {
            currentWeaponIdx = 0;
            currentCooldown = currentWeapon.GetCurrentCoolwon(currentWeaponIdx);
        }

        public override void DoFixedUpdate(GameActor a, float t)
        {
            if (!inputProvider.Attack) return;
            
            inputProvider.Attack = false;
            if (t >= lastShootTime + currentCooldown)
            {
                _requestShootEvt.TriggerEvent(_gameActor, currentWeapon.GetCurrent(currentWeaponIdx));
                    
                currentWeaponIdx++;
                if (currentWeaponIdx >= currentWeapon.DatasCount)
                {
                    currentWeaponIdx = 0;
                }
                currentCooldown = currentWeapon.GetCurrentCoolwon(currentWeaponIdx);
                lastShootTime = t;
            }
        }

        public void ChangeWeapon(WeaponDataAsset weapon)
        {
            if (weapon != overrideWeapon)
            {
                overrideWeapon = weapon;
                ResetWeapon();
            }
        }
    }
}
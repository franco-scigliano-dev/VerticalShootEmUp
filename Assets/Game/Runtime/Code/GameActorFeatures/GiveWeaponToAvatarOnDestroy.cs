using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.VerticalShootEmUp.Weapons;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Assign a Weapon to the player when destroyed, because it's assumed the destruction
    ///                  only can happen if the player collides with it.
    /// Changelog:       
    /// </summary>
    public class GiveWeaponToAvatarOnDestroy : DoSomethingOnDestroy
    {
        [SerializeField] protected WeaponDataAsset _weapon;

        protected override void ChangeSomethingInPlayer(GameActor avatar)
        {
            WeaponShooter w = null;
            if (avatar.GetFeature<WeaponShooter>(out w))
            {
                w.ChangeWeapon(_weapon);
            }
        }
    }
}
using System.Collections.Generic;
using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Weapons
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     This scriptableObject has the data on how the GameActor should fire it's weapons.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(WeaponDataAsset), fileName = nameof(WeaponDataAsset))]
    public class WeaponDataAsset : GameActorIDAsset
    {
        [SerializeField] protected List<WeaponData> _weaponDatas = new List<WeaponData>();
        public int DatasCount => _weaponDatas.Count;

        public float GetCurrentCoolwon(int currentWeaponIdx)
        {
            return _weaponDatas[currentWeaponIdx].cooldown;
        }

        public WeaponData GetCurrent(int currentWeaponIdx)
        {
            return _weaponDatas[currentWeaponIdx];
        }
    }
}
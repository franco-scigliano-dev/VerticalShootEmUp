using System.Collections.Generic;

namespace com.fscigliano.VerticalShootEmUp.Weapons
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Weapon configuration data containing bullet specifications and cooldown timing.
    /// Changelog:       
    /// </summary>
    [System.Serializable]
    public class WeaponData
    {
        public List<BulletData> bulletDatas;
        public float cooldown;
    }
}

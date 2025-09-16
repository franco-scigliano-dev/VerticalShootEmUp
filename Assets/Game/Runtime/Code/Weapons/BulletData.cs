using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Weapons
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Bullet configuration data for weapons. Controls movement behavior and angle settings
    ///                  for bullets when spawned from weapons.
    /// Changelog:       
    /// </summary>
    [System.Serializable]
    public class BulletData
    {
        public GameActorIDAsset bullet;
        public bool setMovement = true;
        public float angle;
        public Vector3 scale = Vector3.one;
        public Vector2 offset;
    }
}
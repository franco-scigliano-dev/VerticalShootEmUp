using com.fscigliano.AsyncPoolingSystem;
using com.fscigliano.VerticalShootEmUp.Events.Custom;
using com.fscigliano.VerticalShootEmUp.GameActorFeatures;
using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.CommonExtensions;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Weapons
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Receives the request event for the shoot, understands the content of the WeaponDataAsset and
    ///                  spawn the bullets according to it.
    /// Changelog:       
    /// </summary>
    public class WeaponsHandler : MonoBehaviour
    {
        [Header("Events"), SerializeField] protected RequestShootEvt _requestShootEvt;
        [SerializeField] protected GameActorEvt _onShootBulletEvt;
        [SerializeField] protected AsyncPoolManager _poolSystem;
        private bool canShoot = false;

        private void OnEnable()
        {
            _requestShootEvt.AddListener(HandleShootRequest);
        }
        private void OnDisable()
        {
            _requestShootEvt.RemoveListener(HandleShootRequest);
        }

        public void HandleInit()
        {
            canShoot = true;
        }

        private void HandleShootRequest(GameActor arg1, WeaponData arg2)
        {
            for (int i = 0; i < arg2.bulletDatas.Count; i++)
            {
                SpawnBullet(arg1.transform.position, arg2.bulletDatas[i]);
            }
        }
        private void SpawnBullet(Vector3 pos, BulletData bdata)
        {
            if (!canShoot) return;

            var o = _poolSystem.Spawn(bdata.bullet, pos + (Vector3)bdata.offset, Quaternion.identity);

            if (o is GameActor actor)
            {
                if (bdata.setMovement)
                {
                    if (actor.GetFeature<Movement>(out Movement k))
                    {
                        k.inputProvider.Intention = MathHelper.DegreeToVector2(-bdata.angle + 90);
                    }
                }
                _onShootBulletEvt.TriggerEvent(actor);    
            }
        }
    }
}

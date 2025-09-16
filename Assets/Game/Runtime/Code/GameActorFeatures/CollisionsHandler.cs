using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActorFeatures;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Collisions
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Registers GameActor colliders and handles collision events using Unity collision callbacks.
    /// Changelog:       
    /// </summary>
    public class CollisionsHandler : GameActorFeatureBase
    {
        [SerializeField] protected Rigidbody2D _rb2d;
        [SerializeField] private ContactFilter2D _contactFilter;

        private Collider2D[] _collisionCache = new Collider2D[16];
        

        private void OnEnable()
        {
            CollidersRegister.Instance.Register(_rb2d, _gameActor);
        }

        private void OnDisable()
        {
            CollidersRegister.Instance.Unregister(_rb2d);
        }

        public override void DoFixedUpdate(GameActor a, float t)
        {
            base.DoFixedUpdate(a, t);
            int c = _rb2d.Overlap(_contactFilter, _collisionCache);
            if (c > 0)
            {
                for (int i = 0; i < c; i++)
                {
                    if (_collisionCache[i].attachedRigidbody == null) continue;
                    var otherActor = CollidersRegister.Instance.Get(_collisionCache[i].attachedRigidbody);
                    CollidersRegister.TriggerCollision(_gameActor, otherActor, _collisionCache[i].gameObject);
                }
            }
        }
    }
}
using System.Collections;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Pool
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Poolable FX object that automatically returns to pool after a specified duration.
    /// Changelog:       
    /// </summary>
    public class FXObject : BasePooleable
    {
        [SerializeField] protected float _duration;
        private Coroutine c;

        protected override void DoOnEnable()
        {
            base.DoOnEnable();
            c = StartCoroutine(DoWaitAndRelease());
        }

        IEnumerator DoWaitAndRelease()
        {
            yield return new WaitForSeconds(_duration);
            c = null;
            SetReleased();
        }

        protected override void DoOnDisable()
        {
            base.DoOnDisable();
            if (c != null)
            {
                StopCoroutine(c);
                c = null;
            }
        }
    }
}
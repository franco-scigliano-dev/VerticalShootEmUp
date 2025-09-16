using com.fscigliano.CommonExtensions;
using com.fscigliano.PoolingSystem;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Pool
{
    public class BasePooleable : MonoBehaviour, IPoolable
    {
        private bool toDestroy = false;
        private PoolManager _poolManager;
        private IDAsset _poolId;

        private void OnEnable()
        {
            toDestroy = false;
            DoOnEnable();
        }

        private void OnDisable()
        {
            DoOnDisable();
        }
        protected virtual void DoOnEnable()
        {
            
        }
        private bool CheckDestroy()
        {
            if (toDestroy)
            {
                _poolManager.Return(_poolId, this);
                return true;
            }

            return false;
        }
        
        // Update is called once per frame
        private void Update()
        {
            if (CheckDestroy())
            {
                return;
            }
            DoUpdate();
        }

        private void FixedUpdate()
        {
            if (CheckDestroy())
            {
                return;
            }
            DoFixedUpdate();
        }
        public void SetReleased()
        {
            toDestroy = true;
        }
        public void SetDestroyed()
        {
            DoOnDestroyed();
            SetReleased();
        }
        protected virtual void DoUpdate()
        {
            
        }
        protected virtual void DoFixedUpdate()
        {
            
        }
        protected virtual void DoOnDestroyed()
        {

        }

        protected virtual void DoOnDisable()
        {
            
        }

        public virtual void OnSpawn()
        {
            
        }

        public virtual void OnReturn()
        {
            
        }

        public void SetPoolManager(PoolManager poolManager, IDAsset poolID)
        {
            _poolManager = poolManager;
            _poolId = poolID;
        }
    }
}
using com.fscigliano.VerticalShootEmUp.Events.Custom;
using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.VerticalShootEmUp.Levels;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Detects when gameactor is destroyed and do something to the avatar when it happens.
    ///                  Useful for power ups.
    /// Changelog:       
    /// </summary>
    public abstract class DoSomethingOnDestroy : GameActorFeatureBase
    {
        [SerializeField] protected CurrentLevelDataAsset _currentLevelData;
        [SerializeField] protected GameActorEvt _onGameActorDestroyedEvt;

        private void OnEnable()
        {
            _onGameActorDestroyedEvt.AddListener(HandleDestruction);
        }

        private void OnDisable()
        {
            _onGameActorDestroyedEvt.RemoveListener(HandleDestruction);
        }

        private void HandleDestruction(GameActor obj)
        {
            if (obj != _gameActor) return;
            // it's itself
            var a = _currentLevelData.GetAvatar();
            if (a != null && a.isActiveAndEnabled)
            {
                ChangeSomethingInPlayer(a);
            }
        }

        protected abstract void ChangeSomethingInPlayer(GameActor avatar);
    }
}
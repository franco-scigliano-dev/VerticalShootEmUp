using com.fscigliano.VerticalShootEmUp.GameActors;

namespace com.fscigliano.VerticalShootEmUp.GameActorFeatures
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Fill avatar's health on destroyed, because it's assumed the destruction
    ///                  only can happen if the player collides with it.
    /// Changelog:       
    /// </summary>
    public class FillAvatarHealthOnDestroy : DoSomethingOnDestroy
    {
        private void HandleDestruction(GameActor obj)
        {
            if (obj != _gameActor) return;
            
            // it's itself
            var a = _currentLevelData.GetAvatar();
            if (a != null && a.isActiveAndEnabled)
            {
                
                
            }
        }

        protected override void ChangeSomethingInPlayer(GameActor avatar)
        {
            AvatarHitPoints hp = null;
            if (avatar.GetFeature<AvatarHitPoints>(out hp))
            {
                hp.Refill();
            }
        }
    }
}
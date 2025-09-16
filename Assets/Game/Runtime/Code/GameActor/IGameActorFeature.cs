namespace com.fscigliano.VerticalShootEmUp.GameActors
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Main interface for Game Actor Features that allows both ScriptableObjects and
    ///                  Monobehaviours to be valid inputs for this system.
    /// Changelog:       
    /// </summary>
    public interface IGameActorFeature
    {
        void DoInit(GameActor a);
        void DoUpdate(GameActor a, float t);
        void DoFixedUpdate(GameActor a, float t);
    }
}
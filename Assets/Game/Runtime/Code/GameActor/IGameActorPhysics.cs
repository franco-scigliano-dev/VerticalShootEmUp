namespace com.fscigliano.VerticalShootEmUp.GameActors
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Physics interface that provides the Movement feature the data needed to function.
    /// Changelog:       
    /// </summary>
    public interface IGameActorPhysics
    {
        float Acceleration { get; }
    }
}
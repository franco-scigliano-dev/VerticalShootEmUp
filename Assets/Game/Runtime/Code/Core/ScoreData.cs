using com.fscigliano.VerticalShootEmUp.GameActors;

namespace com.fscigliano.VerticalShootEmUp.Core
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Score data item to be serialized in GameConfigAsset. Provides the score assigned to
    ///                  a GameActorID
    /// Changelog:       
    /// </summary>
    [System.Serializable]
    public class ScoreData
    {
        public GameActorIDAsset id;
        public int score;
    }
}
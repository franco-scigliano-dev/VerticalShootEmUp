using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Core
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     This components registers statically the bounds of the game to let the gameActors know
    ///                  when it's crossed to be released.
    /// Changelog:       
    /// </summary>
    public class GameplayBounds : MonoBehaviour
    {
        [SerializeField] protected Collider2D _gameplay;
        private static Collider2D gameplay;
        public static Collider2D Gameplay => gameplay;

        private void Awake()
        {
            gameplay = _gameplay;
        }
    }
}
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.UI
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Manages pause functionality and UI popup display state in the game.
    /// Changelog:       
    /// </summary>
    public class PopUp : MonoBehaviour
    {
        private static int pausedLock;

        private void OnEnable()
        {
            pausedLock++;
            RefreshPause();
        }

        private void RefreshPause()
        {
            Time.timeScale = pausedLock > 0 ? 0 : 1;
        }

        private void OnDisable()
        {
            pausedLock--;
            RefreshPause();
        }
    }
}
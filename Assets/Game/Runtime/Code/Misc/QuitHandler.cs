using com.fscigliano.CommonExtensions;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Misc
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Handles application quit requests and manages the quit process.
    /// Changelog:       
    /// </summary>
    public class QuitHandler : MonoBehaviour
    {
        public void RequestQuit()
        {
            RuntimeApplication.QuitGame();
        }
    }
}
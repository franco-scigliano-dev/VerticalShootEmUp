using UnityEngine;
using UnityEngine.Events;

namespace com.fscigliano.VerticalShootEmUp.GameInput
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Checks for key key during gameplay, and calls an UnityEvent.
    /// Changelog:       
    /// </summary>
    public class CheckForKey : MonoBehaviour
    {
        [SerializeField] protected KeyCode _key;
        [SerializeField] protected UnityEvent _onPressKeyUEvt;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(_key) && Time.timeScale >0)
            {
                // pressed key and game is not previously paused.
                _onPressKeyUEvt.Invoke();
            }
        }
    }
}
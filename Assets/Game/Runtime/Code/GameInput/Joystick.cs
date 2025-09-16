using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.PropertyDrawersCollection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.fscigliano.VerticalShootEmUp.GameInput
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Input system joystick handler for player movement and shooting controls.
    /// Changelog:       
    /// </summary>
    [DefaultExecutionOrder(-100)]
    public class Joystick : MonoBehaviour
    {
        [SerializeField, ObjectType(typeof(IInputProvider))]
        protected UnityEngine.Object _inputAsset;

        private IInputProvider cInputAsset;

        private bool attackBeingPressed = false;
        
        [SerializeField] protected InputActionReference _horizontal;
        [SerializeField] protected InputActionReference _vertical;
        private void OnEnable()
        {
            cInputAsset = _inputAsset as IInputProvider;
        }

        private void Update()
        {
            InputSystem.Update();
            cInputAsset.Attack = attackBeingPressed;
            float h = _horizontal.action.ReadValue<float>();
            float v = _vertical.action.ReadValue<float>();
            Vector2 intention = new Vector2(h, v);
            cInputAsset.Intention = intention;
        }

        public void PressAttack(InputAction.CallbackContext c)
        {
            if (c.phase == InputActionPhase.Started)
            {
                attackBeingPressed = true;
            }
            else if (c.phase == InputActionPhase.Canceled)
            {
                attackBeingPressed = false;
            }
        }
        
    }
}
using com.fscigliano.VerticalShootEmUp.Core;
using com.fscigliano.VerticalShootEmUp.GameActors;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.GameInput
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     ScriptableObject-based input provider for player input handling.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(PlayerInputAsset), fileName = nameof(PlayerInputAsset))]
    public class PlayerInputAsset : ScriptableObject, IInputProvider
    {
        private static Vector2 _intention;
        private static bool _attack;

        public Vector2 Intention
        {
            get => _intention;
            set
            {
                _intention = value;
                _intention.x = Mathf.Clamp(_intention.x, -1, 1);
                _intention.y = Mathf.Clamp(_intention.y, -1, 1);
            }
        }

        public bool Attack
        {
            get => _attack;
            set => _attack = value;
        }

        public void ResetValues()
        {
            _intention = Vector2.zero;
            _attack = false;
        }
    }
}
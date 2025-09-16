using com.fscigliano.VerticalShootEmUp.Levels;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Misc
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Follows the current avatar provided by CurrentLevelDataAsset. Used to have a reference for
    ///                  the avatar in the virtual camera.
    /// Changelog:       
    /// </summary>
    public class AvatarFollower : MonoBehaviour
    {
        [SerializeField] protected CurrentLevelDataAsset _levelData;

        private void FixedUpdate()
        {
            var a = _levelData.GetAvatar();
            if (a != null && a.isActiveAndEnabled)
            {
                transform.position = a.transform.position;
            }
        }
    }
}
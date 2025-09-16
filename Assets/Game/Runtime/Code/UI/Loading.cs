using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.UI
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Loading screen functionality. It saves the state to avoid throwing incorrect triggers.
    /// Changelog:       
    /// </summary>
    public class Loading : MonoBehaviour
    {
        [SerializeField] protected Animator _anim;
        [SerializeField] protected string _loadingInTrigger;
        [SerializeField] protected string _loadingOutTrigger;
        private bool isLoadingOn = false;
        public void LoadingIn()
        {
            if (!isLoadingOn)
            {
                _anim.SetTrigger(_loadingInTrigger);
                isLoadingOn = true;
            }
        }

        public void LoadingOut()
        {
            if (isLoadingOn)
            {
                _anim.SetTrigger(_loadingOutTrigger);
                isLoadingOn = false;
            }
        }
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace com.fscigliano.VerticalShootEmUp.UI
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Shows a floating text in screen. Used from LevelAsset to show arbitrary texts
    ///                  according to level
    /// Changelog:       
    /// </summary>
    public class ShowTextUI : MonoBehaviour
    {
        [SerializeField] protected Text _text;
        [SerializeField] protected float _timeToDeactivate = 5;

        public void SetText(string t)
        {
            _text.text = t;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_timeToDeactivate);
            gameObject.SetActive(false);
        }
    }
}
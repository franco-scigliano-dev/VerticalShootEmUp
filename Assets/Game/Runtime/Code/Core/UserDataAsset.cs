using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Core
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Main static game data structure. This data is meant to be static, so it's
    ///                  not be made to be modified in runtime.
    /// Changelog:       
    /// </summary>
    [CreateAssetMenu(menuName = StaticData.k_scriptableObjectsMenuPath + nameof(UserDataAsset), fileName = nameof(UserDataAsset))]
    public class UserDataAsset : ScriptableObject
    {
        public int highscore = 0;

        public void Load()
        {
            string data = PlayerPrefs.GetString(StaticData.savedDataKey, null);
            if (string.IsNullOrEmpty(data))
            {
                Save();
            }
            else
            {
                JsonUtility.FromJsonOverwrite(data, this);
            }
        }

        public void Save()
        {
            string data = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(StaticData.savedDataKey, data);
            PlayerPrefs.Save();
        }
    }
}
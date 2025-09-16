using UnityEngine;
using UnityEngine.InputSystem;

public class RebindSaveLoad : MonoBehaviour
{
    public InputActionAsset actions;

    [SerializeField] protected bool _loadOnEnable = false;
    [SerializeField] protected bool _saveOnDisable = false;
    public void OnEnable()
    {
        if (_loadOnEnable)
            Load();
    }

    public void OnDisable()
    {
        if (_saveOnDisable)
            Save();
    }

    public void Save()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);
    }

    public void Load()
    {
        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
            actions.LoadBindingOverridesFromJson(rebinds);
    }
}

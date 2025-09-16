using System.Threading.Tasks;
using com.fscigliano.AsyncInitialization;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace com.fscigliano.VerticalShootEmUp.Core
{
    public class DataAssetsInit : MonoBehaviour, IInitializable
    {
        [SerializeField] private UserDataAsset _userDataAsset;
        [SerializeField] private AssetReferenceGameObject _loadingPrefab;
        
        public async Task InitAsync()
        {
            await _loadingPrefab.InstantiateAsync().Task;
            _userDataAsset.Load();
        }
    }
}
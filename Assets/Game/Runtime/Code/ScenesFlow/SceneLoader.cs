using System.Collections;
using com.fscigliano.CommonExtensions;
using com.fscigliano.VerticalShootEmUp.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace com.fscigliano.VerticalShootEmUp.ScenesFlow
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Handles scene loading using Addressables with scene name or IDAsset references.
    /// Changelog:       
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        private bool loading = false;
        private static AsyncOperationHandle<SceneInstance> handle; 
        public void LoadScene(string scene)
        {
            if (loading)
            {
                Debug.LogError("LoadScene called while already Loading scene.");
                return;
            }
            Extensions.StartCoroutine(DoLoadScene(scene));
        }

        private IEnumerator DoLoadScene(string scene)
        {
            loading = true;
            var o = SceneManager.LoadSceneAsync(StaticData.LoadingSceneName);
            yield return o;
            o = SceneManager.LoadSceneAsync(scene);
            yield return o;
            loading = false;
        }

        public void LoadScene(IDAsset sceneId)
        {
            LoadScene(sceneId.name);
        }

        public void LoadSceneAddressable(IDAsset sceneId)
        {
            LoadSceneAddressable(sceneId.name);
        }
        
        public void LoadSceneAddressable(string scene)
        {
            if (loading)
            {
                Debug.LogError("LoadSceneAddressable called while already Loading scene.");
                return;
            }
            Extensions.StartCoroutine(LoadSceneAddressableAsync(scene));
        }
        
        private IEnumerator LoadSceneAddressableAsync(string scene)
        {
            loading = true;
            var newHandle = Addressables.LoadSceneAsync(StaticData.LoadingSceneName);
            yield return newHandle;
            if (handle.IsValid())
            {
                handle.Release();
            }
            handle = Addressables.LoadSceneAsync(scene);
            yield return handle;
            if (newHandle.IsValid())
            {
                newHandle.Release();
            }
            loading = false;
        }
    }
}
using System;
using System.Collections.Generic;
using com.fscigliano.VerticalShootEmUp.GameActors;
using com.fscigliano.InterfaceObject;
using com.fscigliano.SFXHandler;
using UnityEngine;

namespace com.fscigliano.VerticalShootEmUp.Audio
{
    /// <summary>
    /// Product Name:    VerticalShootEmUp
    /// Developers:      Franco Scigliano
    /// Description:     Audio listener that plays audio clips when game actors trigger events.
    /// Changelog:       
    /// </summary>
    public class AudioGameActorListener : MonoBehaviour
    {
        [System.Serializable]
        public class AudioGameActor
        {
            public GameActorIDAsset gameActorId;
            public AudioReferenceAsset audioReferenceAsset;
        }

        [SerializeField] protected List<AudioGameActor> _audioGameActorData = new List<AudioGameActor>();
        [SerializeField] protected InterfaceObject<AudioReferencesHandler> _audioHandler;

        private readonly Dictionary<GameActorIDAsset, AudioReferenceAsset> soundAssetdByGameActorId =
            new ();

        private void OnEnable()
        {
            for (int i = 0; i < _audioGameActorData.Count; i++)
            {
                soundAssetdByGameActorId.Add(_audioGameActorData[i].gameActorId,
                    _audioGameActorData[i].audioReferenceAsset);
            }
        }

        public async void OnReceiveEvent(GameActor g)
        {
            try
            {
                if (soundAssetdByGameActorId.TryGetValue(g.Id, out var value))
                {
                    await _audioHandler.Value.PlayAudioAtPositionAsync(value,
                        g.transform.position);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
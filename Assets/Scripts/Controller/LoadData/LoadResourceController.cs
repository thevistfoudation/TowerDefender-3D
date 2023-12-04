using System.Collections.Generic;
using System.IO;
using Base.Core.Sound;
using Model.DataHero;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Controller.LoadData
{
    public class LoadResourceController : SingletonMono<LoadResourceController>
    {
        private Dictionary<string, Object> _resourceCache = new Dictionary<string, Object>();

        #region LoadMethod

        private T Load<T>(string path, string fileName) where T : Object
        {
            var fullPath = Path.Combine(path, fileName);
            if (_resourceCache.ContainsKey(fullPath) is false)
            {
                _resourceCache.Add(fullPath, TryToLoad<T>(path, fileName));
            }

            return _resourceCache[fullPath] as T;
        }

        private static T TryToLoad<T>(string path, string fileName) where T : Object
        {
            var fullPath = Path.Combine(path, fileName);
            var result = Resources.Load<T>(fullPath);
            return result;
        }

        #endregion

        #region Public Load Method


        public GameObject LoadPanel(string panelName)
        {
            return Load<GameObject>(ResourcesFolderPath.UiFolder, panelName);
        }

        public AudioClip LoadAudioClip(SoundType soundType)
        {
            return Load<AudioClip>(ResourcesFolderPath.SoundFolder, soundType.ToString());
        }


        #endregion

        #region LoadDataAsset
        //cách load data từ scriptable Object
        public DataWariorCollection LoadDataWariorCollection()
        {
            var path = string.Format(ResourcesFolderPath.DataFolder, ResourcesFolderPath.DataFolderHero);
            return Load <DataWariorCollection>(path, "HeroData");
        }

    #endregion
}
}

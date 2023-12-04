using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model.DataHero
{
    [Serializable]
    public struct DataArcher
    {
        [GUIColor(0f, 1f, 0.8f)]
        public int level;
        public float speed;
        [GUIColor(0f, 1f, 0.8f)]
        public float hp;
        public float defend;
        [GUIColor(0f, 1f, 0.8f)]
        public float rangeAtk;
    }
}
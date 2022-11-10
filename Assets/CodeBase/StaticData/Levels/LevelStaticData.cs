﻿using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public LevelId LevelId;
        public int AmuletsCount;
        public GameObject Prefab;
    }
}
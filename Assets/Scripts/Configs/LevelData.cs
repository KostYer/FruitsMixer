using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Configs
{
    [System.Serializable]
    public class LevelData
    {
        public int LevelNumber=-1;
        public Color TargetColor;
        public List<FruitType> FruitTypes = new List<FruitType>();
    }
}
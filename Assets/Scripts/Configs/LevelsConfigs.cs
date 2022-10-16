using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "LevelConfigsSO", menuName = "ScriptableObjects/LevelConfigsSO")]
    public class LevelsConfigs : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levelData = new List<LevelData>();


        public LevelData GetLevelConfigs(int lvl)
        {
           return _levelData.FirstOrDefault(x => x.LevelNumber == lvl);
        }

    }
}
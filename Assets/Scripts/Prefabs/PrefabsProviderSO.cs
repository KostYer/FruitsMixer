using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.Prefabs
{
    [CreateAssetMenu(fileName = "PrefabsProviderSO", menuName = "ScriptableObjects/PrefabsProviderSO")]
    public class PrefabsProviderSO : ScriptableObject
    {
        [SerializeField] private List<FruitPrefab> _fruitPrefabs = new List<FruitPrefab>();

        public GameObject GetFruitPrefab(FruitType fruitType)
        {
            return _fruitPrefabs.FirstOrDefault(x => x.FruitType == fruitType).Prefab;
        }
    }


    [System.Serializable]
    public class FruitPrefab
    {
        public FruitType FruitType;
        public GameObject Prefab;
    }
}
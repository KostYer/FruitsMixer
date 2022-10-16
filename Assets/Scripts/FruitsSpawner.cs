using System.Collections.Generic;
using DefaultNamespace.Prefabs;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class FruitsSpawner : MonoBehaviour
    {
        
        [SerializeField] private Transform _fruitsRoot;
        [SerializeField] private PrefabsProviderSO _prefabsProvider;
        private List<Fruit> _spawnedFruits = new List<Fruit>();
        public readonly float SpawnDelay = 0.2f;

        public void SpawnFruit(FruitType fruitType, Vector3 pos)
        {
            var prefab = _prefabsProvider.GetFruitPrefab(fruitType);
            var go = GameObject.Instantiate(prefab, pos, prefab.transform.rotation);
            go.transform.SetParent(_fruitsRoot);
            _spawnedFruits.Add(go.GetComponent<Fruit>());
        }
        
        public void RemoveFruits()
        {
            foreach (var f in _spawnedFruits)
            {
                f.RemoveFruit();
            }
            _spawnedFruits.Clear();
        }
    }
}
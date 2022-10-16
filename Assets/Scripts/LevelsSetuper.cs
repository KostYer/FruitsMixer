
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LevelsSetuper : MonoBehaviour
    {
        private int _currentLevel = -1;
       
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private LevelsConfigs _levelsConfigs;
        [SerializeField] private FruitsSpawner _fruitsSpawner;
        [SerializeField] private GameplayHandler _gameplayHandler;
        [SerializeField] private JuiceHandler _referenceJuice;
        [SerializeField] private UIHandler _uiHandler;
        private int _levelsCount = 3;
       
        private void Awake()
        {
            _uiHandler.OnBeginGame += OnBeginGame;
            
        }

        private void OnBeginGame()
        {
            _currentLevel = 1;
            SetupLevel();
        }

        private void SetupLevel()
        {
            SpawnFruits(_currentLevel);
            _uiHandler.OnLevelStart(_currentLevel);
            var levelColor = _levelsConfigs.GetLevelConfigs(_currentLevel).TargetColor;
            _gameplayHandler.Init(levelColor, this);
            _referenceJuice.SetColor(levelColor);
            _referenceJuice.ShowJuice(true);
        }

        public void SpawnFruits(int level)
        {
            var fruitTypes = _levelsConfigs.GetLevelConfigs(level).FruitTypes;
            for (int i = 0; i < fruitTypes.Count; i++)
            {
                var fruitType = fruitTypes[i];
                var pos = _spawnPoints[i].position;
                _fruitsSpawner.SpawnFruit(fruitType, pos);
            }

        }

        public void OnNextLevel(bool isLevelWon)
        {
            
            var lvl = isLevelWon ? _currentLevel+1 : _currentLevel;
            lvl = lvl > _levelsCount ? 1 : lvl;
            _currentLevel = lvl;
            SetupLevel();

        }
    }
}
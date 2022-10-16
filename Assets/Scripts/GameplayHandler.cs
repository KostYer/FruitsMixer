using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHandler : MonoBehaviour
{
    [SerializeField] private TapsProvider tapsProvider;
    [SerializeField] private BlenderHandler _blender;
    [SerializeField] private FruitsSpawner _fruitsSpawner;
    [SerializeField] private Button _mixButton;
    [SerializeField] private UIHandler _uiHandler;
    [SerializeField] private JuiceHandler _juice;
    private WinChecker _winChecker = new WinChecker();
    private ColorBlender _colorBlender = new ColorBlender();
    private List<Color> _colorsPicked = new List<Color>();
    public Color _desiredColor;
    private bool _isLevelWon;

    private LevelsSetuper _levelsSetuper;
    public void Init(Color levelColor, LevelsSetuper levelsSetuper)
    {
        if (_levelsSetuper == null)
        {
            _levelsSetuper = levelsSetuper;
        }

        _desiredColor = levelColor;
        tapsProvider.OnFruitTap += OnFruitTap;
        _mixButton.onClick.AddListener(OnMixButtonTapped);
        _mixButton.interactable = false;
        _uiHandler.OnFinishLevel += OnLevelCompleted;
    }

    private void OnMixButtonTapped()
    {
       
        tapsProvider.OnFruitTap -= OnFruitTap;
     
        _mixButton.onClick.RemoveAllListeners();
        _mixButton.interactable = false;
        var avgColor = _colorBlender.AverageColour(_colorsPicked);
        _blender.OpenBlender(false);
        var colorMatch =  _colorBlender.CompareColors(avgColor, _desiredColor);
        _isLevelWon = _winChecker.IsWin(colorMatch);
        _fruitsSpawner.RemoveFruits();
         InvokeLevelEnd(_isLevelWon,  _desiredColor, avgColor, colorMatch);
        _juice.ShowJuice(true);
        _juice.SetColor(avgColor);
        
        _colorsPicked.Clear();
    }


    private void OnFruitTap(Fruit fruit)
    {
        _colorsPicked.Add(fruit.FruitColor);
        _blender.AddFruit(fruit);
        _mixButton.interactable = true;
       StartCoroutine(SpawnAfterTap(fruit.FruitType, fruit.transform.position)); 


    }

    private IEnumerator SpawnAfterTap(FruitType type, Vector3 pos)
    {
        yield return new WaitForSeconds(_fruitsSpawner.SpawnDelay);
        _fruitsSpawner.SpawnFruit(type, pos);
        
        
    }

    private void InvokeLevelEnd(bool win, Color aimCol, Color resultCol, int result)
    {
        _uiHandler.OnLevelEnd(win, aimCol, resultCol, result  );
    }

    

    private void OnLevelCompleted()
    {
       
        _levelsSetuper.OnNextLevel(_isLevelWon);
        _blender.OnLevelFinish();
        _juice.ShowJuice(false);
        _uiHandler.OnFinishLevel -= OnLevelCompleted;
        
    }
}

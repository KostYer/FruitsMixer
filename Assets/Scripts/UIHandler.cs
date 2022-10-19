using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIHandler : MonoBehaviour
    {
        [Header("StartPanel")]
        [SerializeField] private RectTransform _startPanel;
        [SerializeField] private Button _startGame;
        [Space]
        [Header("LevelEndPanel")]
        [SerializeField] private RectTransform _root;
        [SerializeField] private Image _aim;
        [SerializeField] private Image _result;
        [SerializeField] private TMP_Text _percent;
        [SerializeField] private TMP_Text _winLose;
        [SerializeField] private Button _continue;
        [SerializeField] private TMP_Text _buttonText;
        [SerializeField] private TMP_Text _levelNumber;
        private float _levelEndDelay = 1f;
        private float _alpha = .6f;
        public event Action OnBeginGame;
        public event Action OnFinishLevel;
        private void Awake()
        {
            _startPanel.gameObject.SetActive(true);
            _startGame.onClick.AddListener(OnGameStartClicked);
            _root.gameObject.SetActive(false);
            _continue.onClick.AddListener(OnLevelFinish);
        }


        private void OnGameStartClicked()
        {
            _startPanel.gameObject.SetActive(false);
            OnBeginGame?.Invoke();
        }

        public void OnLevelEnd(bool win, Color aimCol, Color resultCol, float result)
        {
            StartCoroutine(ShowEndLevelUI(win, aimCol, resultCol, result));
        }


        private IEnumerator ShowEndLevelUI(bool win, Color aimCol, Color resultCol, float result)
        {
            yield return new WaitForSeconds(_levelEndDelay);
          
            aimCol.a = _alpha;
            resultCol.a = _alpha;
            _aim.color = aimCol;
            _result.color = resultCol;
             
            
            _percent.text = (1-result)*100f  + "%";
            
            _winLose.text = win? "You won": "Try again";
            _buttonText.text = win?  "Next":  "Restart";

            _root.gameObject.SetActive(true);
        }

        private void OnLevelFinish()
        {
            OnFinishLevel?.Invoke();
            _root.gameObject.SetActive(false);
        }

        public void OnLevelStart(int lvl)
        {
            _levelNumber.text = lvl.ToString();
        }
    }
    
    
}
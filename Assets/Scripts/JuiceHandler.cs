using UnityEngine;


namespace DefaultNamespace
{
    public class JuiceHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _juice;
        [SerializeField] private Renderer _renderer;
        private float _surfColorMul = 0.45f;
        private int _colorMainID;
        private int _colorSurfID;
      
        private void Awake()
        {
            _colorMainID = Shader.PropertyToID("_SurfaceColor");
            _colorSurfID = Shader.PropertyToID("_LiquidColor");
            ShowJuice(false);
        }
        
        public void ShowJuice(bool on)
        {
            _juice.gameObject.SetActive(on);
        }

        public void SetColor(Color color)
        {
            _renderer.sharedMaterial.SetColor(_colorMainID, color);
            var surfColor = new Color(color.r * _surfColorMul, color.g * _surfColorMul, color.b * _surfColorMul, 1f);
            _renderer.sharedMaterial.SetColor(_colorSurfID, surfColor);
        }


         

    }
}
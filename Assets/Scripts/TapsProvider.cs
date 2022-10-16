using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TapsProvider : MonoBehaviour
    {
        [SerializeField] private LayerMask _fruitsLayer;
        [SerializeField] private LayerMask _buttonLayer;
        [SerializeField] private Camera _mainCamera;
        private bool _isActive = true;

        public event Action<Fruit> OnFruitTap; 
   

        private void Update()
        {
            if (_isActive == false) return;


            if (Input.GetMouseButtonDown(0))
            {
                var tap = Input.mousePosition;

                Ray ray = _mainCamera.ScreenPointToRay(tap);

                 if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _fruitsLayer))
                {
                    var fruit = hit.collider.gameObject.GetComponent<Fruit>();
                    if (fruit != null)
                    OnFruitTap?.Invoke(fruit);
                } 
                
                  /*
                  if (Physics.Raycast(ray, out RaycastHit buttonHit, Mathf.Infinity, _buttonLayer))
                {
                    OnButtonTap?.Invoke();
                }*/
            }



        }
    }
}
 
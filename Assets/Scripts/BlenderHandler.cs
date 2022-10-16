
using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class BlenderHandler : MonoBehaviour
    {
        
        [SerializeField] private LidRotator _lidRotator;
        [SerializeField] private Transform _blenderTop;
        [SerializeField] private Animator _animator;
       
        private float _fruitMoveDuration = .8f;
        private float _shakeDelay = .02f;
        private bool _isFirstFruitAdded;
        private string _shakeClipName = "Shake";
        

     
        private void ShakeBlender()
        {
            _animator.PlayInFixedTime(_shakeClipName);
        }

        public void AddFruit(Fruit fruit)
        {
           fruit.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(MoveToTop(fruit.transform));
            if (!_isFirstFruitAdded)
            {
                OpenBlender(true);
                _isFirstFruitAdded = true;
            }

        }

        public void OpenBlender(bool open)
        {
            _lidRotator.OpenLid(open);
        }
        
        private IEnumerator MoveToTop(Transform movable)
        {
            Vector3 start = movable.position;
            Vector3 end = _blenderTop.position;
            Transform target = movable;
            float time = 0;
            while (time <= _fruitMoveDuration)
            { 
                float value = time / _fruitMoveDuration;
                time += Time.deltaTime;
                var pos = Parabola(start, end, 0.3f, value );        
                target.position = pos;
                yield return null;
            }
            movable.GetComponent<Rigidbody>().isKinematic = false;
            yield return new WaitForSeconds(_shakeDelay);
            ShakeBlender();
        }
        
        
        public Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
        {
            Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

            var mid = Vector3.Lerp(start, end, t);

            return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
        }

       
        public void OnLevelFinish()
        {
            _isFirstFruitAdded = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_blenderTop.position, 0.03f);
        }
    }
}
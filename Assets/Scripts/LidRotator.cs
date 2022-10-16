using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidRotator : MonoBehaviour
{
     [SerializeField] private Transform _root;
     [SerializeField] private Transform _lid;
     [SerializeField] private float _angleGrad;
     [SerializeField] private float _speed;
     
     public void OpenLid(bool open)
     {
          StartCoroutine(RotationCor(open));
     }

     private IEnumerator RotationCor(bool open)
     {
          var angle = open ? _angleGrad : -_angleGrad;
          var time = 0f;
          while (time<=1/_speed)
          {
               _lid.transform.RotateAround(_root.transform.position, Vector3.right, angle*_speed * Time.fixedDeltaTime );
               time += Time.fixedDeltaTime;
               yield return new WaitForFixedUpdate();
          }
          
     }

}

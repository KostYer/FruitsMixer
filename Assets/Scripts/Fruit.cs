using UnityEngine;

namespace DefaultNamespace
{
    public class Fruit  : MonoBehaviour
    {
        public FruitType FruitType;
        public Color FruitColor;

        public void RemoveFruit()
        {
           var renderer =  gameObject.GetComponent<Renderer>();
           renderer.enabled = false;
           Destroy(this.gameObject, 1f);
        }
    }


    public enum FruitType
    {
        Banana,
        Apple,
        Cherry,
        Cucamber, 
        Eggplant, 
        Tomato,
        Orange
    }
}
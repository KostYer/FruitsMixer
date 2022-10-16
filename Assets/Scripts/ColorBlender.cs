using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ColorBlender
    {
        
        public Color AverageColour(List<Color> colors)
        {

            float totalRed = 0f;
            float totalGreen = 0f;
            float totalBlue = 0f;

            foreach (Color colour in colors)
            {
                totalRed += colour.r;
                totalGreen += colour.g;
                totalBlue += colour.b;
            }

            float numColours = colors.Count;
            var finalColor = new Color(totalRed / numColours, totalGreen / numColours, totalBlue / numColours);
            return finalColor;
        }


        public int CompareColors(Color a, Color b)
        {
            var result =
                1.0 - (
                    Math.Abs(a.r - b.r)/3f +
                    Math.Abs(a.g - b.g)/3f +
                    Math.Abs(a.b - b.b)/3f
                );
            
           var resultInt = Mathf.RoundToInt((float)result*100);
  
            return resultInt;
        }
    }
}
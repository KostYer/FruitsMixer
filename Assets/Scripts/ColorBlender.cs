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


        public float GetColorDiff(Color a, Color b)
        {
            //redMean method  https://en.wikipedia.org/wiki/Color_difference
            var rDiff = a.r - b.r;
            var gDiff = a.g - b.g;
            var bDiff = a.b - b.b; 
            var rMul = 0.5f * (a.r+b.r);


            
            var colorDistSquared = (2/256 + rMul ) * Mathf.Pow(rDiff,2) + 4 *  Mathf.Pow(gDiff,2) +
                                   (2/256+ ((1-1/256)- rMul)) *Mathf.Pow(bDiff,2) ;
            
            var result = (decimal)Mathf.Sqrt(colorDistSquared);
            var rounded = Decimal.Round(result, 2);
            return (float)rounded;
        }
    }
}
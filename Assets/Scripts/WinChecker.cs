using UnityEngine;

namespace DefaultNamespace
{
    public class WinChecker
    {
        private const float _winPrecent = 0.9f;

        public bool IsWin(float value)
        {

            return value < 1 - _winPrecent;
        }
    }
}
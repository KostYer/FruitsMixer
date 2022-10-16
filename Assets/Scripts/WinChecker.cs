namespace DefaultNamespace
{
    public class WinChecker
    {
        private const int _winPrecent = 90;

        public bool IsWin(int value)
        {
            return value >= _winPrecent;
        }
    }
}
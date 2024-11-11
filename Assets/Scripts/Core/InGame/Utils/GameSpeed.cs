namespace Core.InGame.Utils
{
    public class GameSpeed
    {
        private int _gameSpeed = 1;

        public void SetGameSpeed()
        {
            _gameSpeed = 2;
        }

        public int GetGameSpeed()
        {
            return _gameSpeed;
        }
    }
}
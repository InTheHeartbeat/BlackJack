
namespace BlackJack.Base
{
    public class ConfigProvider
    {
        public static ConfigProvider Provider => GetInstance();
        private static ConfigProvider _instance;

        private static ConfigProvider GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConfigProvider();
            }
            return _instance;
        }


        public GameConfig CurrentConfig = new GameConfig();
    }
}

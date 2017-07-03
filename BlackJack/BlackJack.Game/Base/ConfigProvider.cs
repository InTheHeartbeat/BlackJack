using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Base
{
    public class ConfigProvider
    {
        public static ConfigProvider Provider => _instance ?? (_instance = new ConfigProvider());
        private static ConfigProvider _instance;

        public GameConfig CurrentConfig = new DefaultGameConfig();
    }
}

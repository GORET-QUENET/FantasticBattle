using System.Collections.Generic;

namespace FantasticBattle
{
    public class GameConfig : Singleton<GameConfig>
    {
        public List<string> UnitsName { get; set; }

        public GameConfig()
        {
            UnitsName = new List<string>
            {
                "orc_simple",
                "humain_simple"
            };
        }
    }
}

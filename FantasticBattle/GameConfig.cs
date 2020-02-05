using System.Collections.Generic;

namespace FantasticBattle
{
    public class GameConfig : Singleton<GameConfig>
    {
        public List<string> UnitsName { get; set; }

        public GameConfig()
        {
            UnitsName = new List<string>();
            UnitsName.Add("orc_simple");
            UnitsName.Add("humain_simple");
        }
    }
}

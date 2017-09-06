using System.Collections.Generic;

namespace pokeinfo {
    public class Pokemon {
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public List<string> types { get; set; }

        public List<string> sprites { get; set; }
    }
}

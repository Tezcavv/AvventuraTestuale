using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class Npc {

        private string name;
        private string dialogue;

        public Npc(string name, string dialogue) {
            this.name = name;
            this.dialogue = dialogue;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Dialogue {
            get { return dialogue; }
            set { dialogue = value; }
        }

    }
}


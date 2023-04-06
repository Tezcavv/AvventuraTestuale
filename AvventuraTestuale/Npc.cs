using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class Npc {

        private string name;
        private Dialogue dialogue;

        public Npc(string name, Dialogue dialogue) {
            this.name = name;
            this.dialogue = dialogue;
        }

        public string Name => name;

        public string Dialogue => dialogue.GetCurrentDialogue();
        

    }
}


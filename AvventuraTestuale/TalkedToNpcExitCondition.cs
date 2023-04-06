using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    internal class TalkedToNpcExitCondition : ExitCondition {

        private Npc npc;

        public TalkedToNpcExitCondition( Npc npc) {
            this.npc = npc;
        }


        public override bool IsValid() {
            return Player.HasTalkedToNpc(npc);
        }
    }
}

using AvventuraTestuale.Conditions;
using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class WorldFactory {


        public static Ambient CreateAmbients() {

            Ambient ambient = new Ambient(Vector2.Zero, AmbientID.AM01, "Vicolo", "Uno Sporco vicolo di Roma");
            Npc npc1 = new Npc(NpcID.PG01, "Totti", "il gran campione della Roma");
            Dialogue dial1 = new Dialogue(DialogueID.DIAL01, "AO COME STAI?");
            Dialogue dial2 = new Dialogue(DialogueID.DIAL02, "PARLA CON RINGO", new ConditionTalkToNpc(NpcID.PG02, DialogueID.DIAL06));
            Dialogue dial3 = new Dialogue(DialogueID.DIAL03, "bravo bravo", new LastDialogue());
            Npc npc2 = new Npc(NpcID.PG02, "Ringo", "Gattuso");
            Dialogue dial4 = new Dialogue(DialogueID.DIAL06, "AWOOO");

            npc1.AddDialogues(dial1, dial2, dial3);
            npc2.AddDialogues(dial4);

            ambient.AddNpcs(npc1, npc2);
            return ambient;


        }

    }
}

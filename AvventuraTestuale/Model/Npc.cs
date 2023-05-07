using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {

    public enum NpcID { PG01,PG02,PG03,PG04,PG05,PG06,PG07}
    public class Npc {

        public static Dictionary<NpcID, Npc> allNpcs= new Dictionary<NpcID, Npc>();

        private NpcID id;
        private string name;
        private List<Dialogue> dialogues;
        private int dialogueLine;

        public Npc(NpcID id, string name, List<Dialogue> dialogues) {
            this.id = id;
            this.name = name;
            this.dialogues = dialogues;
            dialogueLine = 0;
            allNpcs.Add(id, this);
        }

        public NpcID Id { get => id; }

        public string GetDialogue() {

            if (dialogues[dialogueLine].IsObsolete())
                dialogueLine++;

            if (!Player.Instance.HadConversation(id, dialogues[dialogueLine].ID)) {
                dialogues[dialogueLine].ExecuteActions();
            }

            Player.Instance.AddConversation(id, dialogues[dialogueLine].ID);
            return dialogues[dialogueLine].Text;
        }


    }
}

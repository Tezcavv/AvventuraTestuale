using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {

    public enum NpcID { PG01,PG02,PG03,PG04,PG05,PG06,PG07}
    public class Npc : IExaminable {

        public static List<Npc> allNpcs= new List<Npc>();

        private NpcID id;
        private string name;
        private string description;
        private List<Dialogue> dialogues;

        public Npc(NpcID id, string name, string description, List<Dialogue> dialogues) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.dialogues = dialogues;
            allNpcs.Add(this);
        }
        public Npc(NpcID id, string name, string description) : this(id,name,description,new List<Dialogue>()) {

        }

        public NpcID Id { get => id; }
        public string Name => name;
        public string Description => description;

        public void AddDialogues(params Dialogue[] dialogues) {
            foreach (Dialogue dial in dialogues)
                this.dialogues.Add(dial);
        }

        public string GetDialogue() {


            while (dialogues[0].IsObsolete() && Player.HadConversation(id, dialogues[0].ID))
                dialogues.RemoveAt(0);

            dialogues[0].ExecuteActions();
            Player.AddConversation(id, dialogues[0].ID);


            return dialogues[0].Text;
        }

    }
}

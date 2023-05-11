using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {

    public enum HotAreaID { HH01,HH02,HH03,HH04,HH05,HH06,HH07 }
    public class HotArea : IExaminable{

        private HotAreaID id;
        // Ogni Stato ha la sua Mappa di Azioni - Dialoghi
        private Dictionary<Action, List<Dialogue>> dialogues;
        private string name;

        /// <summary>
        ///  Crea la HotArea con tutte le relative 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dialogues">Mappa di Azioni - Dialoghi ORDINATA</param>
        public HotArea(HotAreaID id, string name, Dictionary<Action, List<Dialogue>> dialogues) {
            this.id = id;
            this.name = name;
            this.dialogues = dialogues;
        }

        public HotArea(HotAreaID id, string name) : this(id, name, new Dictionary<Action, List<Dialogue>>()) { }

        public void AddDialogue( Action action,params Dialogue[] dialogue) {

            if (!dialogues.ContainsKey(action)) {
                dialogues[action]=new List<Dialogue>();
            }
            
            dialogues[action].AddRange(dialogue);
        }

        public HotAreaID Id { get => id; }
        public string Name => name.ToLower();
        public string Description => Examine(Action.ESAMINA);

        private string Examine(Action action) {

            if (!dialogues.ContainsKey(action)) {
               
                return Program.COMMAND_NOT_VALID;
            }

            while (dialogues[action][0].IsObsolete()) {

                if (dialogues[action].Count <= 1) {
                  
                    return "...";
                }

                if (!Player.HadConversation(id, dialogues[action][0].ID)) {
                    Player.AddConversation(id, dialogues[action][0].ID);
                    dialogues[action][0].ExecuteActions(); //TO_TEST

                }
                dialogues[action].RemoveAt(0);
            }

            Player.AddConversation(id, dialogues[action][0].ID);
            dialogues[action][0].ExecuteActions();
            return dialogues[action][0].Text;
        }


        //
        public void PlayDialogue(Action action) {

            if (!dialogues.ContainsKey(action)) {
                Program.SlowlyWrite(Program.COMMAND_NOT_VALID);
                return;
            }

            if (dialogues[action][0].IsObsolete() && Player.HadConversation(id, dialogues[action][0].ID)) {

                if (dialogues[action].Count <= 1) {
                    Program.SlowlyWrite("...");
                    return;
                }

                dialogues[action].RemoveAt(0);
            }
            Player.AddConversation(id, dialogues[action][0].ID);
            Program.SlowlyWrite(dialogues[action][0].Text);
            dialogues[action][0].ExecuteActions();
            
        }





        
    }
}

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

        public HotAreaID Id { get => id; }
        public string Name => name;
        public string Description => PlayDialogue(Action.ESAMINA);

        public string PlayDialogue(Action action) {

            if (!dialogues.ContainsKey(action)) {
                Program.SlowlyWrite(Program.COMMAND_NOT_VALID);
                return Program.COMMAND_NOT_VALID;
            }

            CheckForConversation(action);

            while (dialogues[action][0].IsObsolete()) {

                if (dialogues[action].Count <= 1)

                    return "...";
                dialogues[action].RemoveAt(0);
                CheckForConversation(action);
            }

            return dialogues[action][0].Text;
            
        }

        private void CheckForConversation(Action action) {
            if (!Player.HadConversation(id, dialogues[action][0].ID)) {
                dialogues[action][0].ExecuteActions();
                Player.AddConversation(id, dialogues[action][0].ID);
            }
        }




        
    }
}

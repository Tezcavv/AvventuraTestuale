using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {

    public enum HotAreaID { HH01,HH02,HH03,HH04,HH05,HH06,HH07 }
    public class HotArea {

        private HotAreaID id;
        // Ogni Stato ha la sua Mappa di Azioni - Dialoghi
        private List<Dictionary<Action, Dialogue>> dialogues;
        private string name;
        private int status;

        /// <summary>
        ///  Crea la HotArea con tutte le relative 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dialogues">Mappa di Azioni - Dialoghi ORDINATA</param>
        public HotArea(HotAreaID id, string name, List<Dictionary<Action,Dialogue>> dialogues) {
            this.id = id;
            this.name = name;
            this.dialogues = dialogues;
            status = 0;
        }

        public HotAreaID Id { get => id; }

        public string GetDialogue(Action action) {

            if (dialogues[status][action].IsObsolete() && dialogues.Count < status) {
                status++;
            }
            
            return dialogues[status][action].Text;
        }




        
    }
}

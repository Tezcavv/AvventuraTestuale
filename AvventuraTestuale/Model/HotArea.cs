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
        private Dictionary<int,Dictionary<Action, string>> dialogues;
        private int status;

        /// <summary>
        ///  Crea la HotArea con tutte le relative 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dialogues">Mappa di Azioni - Dialoghi in ordine cronologico</param>
        public HotArea(HotAreaID id, params Dictionary<Action,string>[] dialogues) {

            this.dialogues = new Dictionary<int, Dictionary<Action, string>>();
            this.id = id;
            for(int i = 0; i < dialogues.Length; i++) {
                this.dialogues.Add(i, dialogues[i]);
            }
            status = 0;
        }

        public string GetDialogue(Action action) {
            return dialogues[status][action];
        }



        
    }
}

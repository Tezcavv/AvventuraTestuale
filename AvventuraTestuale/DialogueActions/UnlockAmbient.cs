using AvventuraTestuale.Conditions;
using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.DialogueActions {
    public class UnlockAmbient : IDialogueAction {

        private AmbientID ambID;
        public UnlockAmbient(AmbientID id) {
            ambID= id;
        }
        public void Execute() {
            Ambient.allAmbients.Find(amb => amb.AmbientID == ambID).SetActive(true);
        }
    }
}

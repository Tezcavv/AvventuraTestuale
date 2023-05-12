using AvventuraTestuale.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.DialogueActions {
    public class EndGame : IDialogueAction {
        public void Execute() {
            Program.gameIsRunning= false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    //creiamo la classe Dialogo da usare con gli NPC
    public class Dialogue {

        private List<DialogueLine> lines;
        private int lineIndex;
        private DialogueLine CurrentLine => lines[lineIndex];

        public Dialogue(DialogueLine onlyLine) {
            lines = new List<DialogueLine> { onlyLine };
            lineIndex= 0;
        }


        public Dialogue(List<DialogueLine> lines) {
            this.lines = new List<DialogueLine>(lines) ;
            lineIndex = 0;
        }

        public string GetCurrentDialogue() {

            if(lineIndex >= lines.Count && CurrentLine.IsObsolete) {
                return CurrentLine.Message;
            }

            if (CurrentLine.IsObsolete) {
                lineIndex++;
                return GetCurrentDialogue();
            }

            return CurrentLine.Message;
        }




    }
}

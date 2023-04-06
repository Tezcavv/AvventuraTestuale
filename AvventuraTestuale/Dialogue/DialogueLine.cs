using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class DialogueLine {

        private string message;
        private IExitCondition exitCondition;
        //exitCondition

        public DialogueLine(string msg,IExitCondition exitCondition) {
            this.message = msg;
            this.exitCondition = exitCondition;
        }
        public string Message => message;
        public bool IsObsolete => exitCondition.IsValid();


    }
}

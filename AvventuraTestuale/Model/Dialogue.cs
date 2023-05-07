using AvventuraTestuale.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {

    public enum DialogueID { DIAL01,DIAL02,DIAL03,DIAL04,DIAL05,DIAL06,DIAL07}
    public abstract class Dialogue {

        protected DialogueID id;
        protected string text;
        protected IExitCondition[] exitConditions;
        private List<IDialogueAction> actionList;

        public Dialogue(DialogueID id ,string text, params IExitCondition[] conditions) {
            this.id = id;
            this.text = text;
            exitConditions = conditions;
            actionList= new List<IDialogueAction>();
        }
        public void AddAction(IDialogueAction action) {
            actionList.Add(action);
        }

        public DialogueID ID => id;
        public string Text => text;

        public void ExecuteActions() {
            actionList.ForEach(action => action.Execute());
        }

        public abstract bool IsObsolete();
    }
}

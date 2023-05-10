using AvventuraTestuale.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {

    public enum DialogueID { DIAL01,DIAL02,DIAL03,DIAL04,DIAL05,DIAL06,DIAL07,DIAL08,DIAL09,DIAL10,DIAL11,DIAL12,DIAL13,DIAL14}
    public class Dialogue {

        protected DialogueID id;
        protected string text;
        protected List<IExitCondition> exitConditions;
        private List<IDialogueAction> actionList;

        public Dialogue(DialogueID id ,string text) {
            this.id = id;
            this.text = text;
            exitConditions = new List<IExitCondition>();
            actionList= new List<IDialogueAction>();
        }

        public Dialogue(DialogueID id, string text, List<IExitCondition> exitConditions, List<IDialogueAction> actions) : this(id, text) {

            this.exitConditions = exitConditions;
            this.actionList = actions;

        }

        public Dialogue(DialogueID id, string text, params IExitCondition[] exitConditions) : this(id, text) {
            this.exitConditions.AddRange(exitConditions);
        }

        public Dialogue(DialogueID id, string text, params IDialogueAction[] actions) : this(id, text) {
            actionList?.AddRange(actions);
        }

        public void AddExitCondition(params IExitCondition[] exitCondition) {
            exitCondition?.ToList().ForEach(exitConditions.Add);
        }

        public void AddAction(params IDialogueAction[] action) {
            action?.ToList().ForEach(actionList.Add);
        }

        public DialogueID ID => id;
        public string Text => text;

        public void ExecuteActions() {
            actionList.ForEach(action => action.Execute());
        }

        public bool IsObsolete() {

            foreach (IExitCondition condition in exitConditions) {
                if (!condition.IsConditionMet())
                    return false;
            }

            return true;
        }
    }
}

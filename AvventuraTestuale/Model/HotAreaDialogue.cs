using AvventuraTestuale.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {
    public class HotAreaDialogue : Dialogue {

        private HotAreaID hotAreaID;
        
        public HotAreaDialogue(HotAreaID hotAreaID,DialogueID id, string text, params IExitCondition[] conditions) : base(id, text, conditions) {
        }

        public HotAreaID HotAreaID { get => hotAreaID; }

        //public override bool IsObsolete() {

            
        //    foreach (IExitCondition condition in exitConditions) {
        //        if (!condition.IsConditionMet())
        //            return false;
        //    }

        //    return true;
        //}
    }
}

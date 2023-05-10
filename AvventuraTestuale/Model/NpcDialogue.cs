using System;
using System.Collections.Generic;
using AvventuraTestuale.Conditions;

namespace AvventuraTestuale.Model {
    public class NpcDialogue : Dialogue {

        private NpcID npcID;
        



        public NpcDialogue(NpcID npcId, DialogueID id, string text, params IExitCondition[] exitConditions) : base(id, text, exitConditions) {
            npcID= npcId;
        }
        public NpcDialogue(NpcID npcId, DialogueID id, string text, params IDialogueAction[] actions) :base(id,text,actions){
            npcID = npcId;
        }
        public NpcDialogue(NpcID npcId, DialogueID id, string text, List<IExitCondition> exitConditions,List<IDialogueAction> actions) : base(id, text, exitConditions, actions) {
            npcID= npcId;
        }
        public NpcDialogue(NpcID npcId, DialogueID id, string text) : base(id, text) {
            npcID = npcId;
        }


        public NpcID NpcID { get => npcID; }
        
      


        //public override bool IsObsolete() {


        //    foreach (IExitCondition condition in exitConditions) {
        //        if (!condition.IsConditionMet())
        //            return false;
        //    }

        //    return true;
        //}
    }
}

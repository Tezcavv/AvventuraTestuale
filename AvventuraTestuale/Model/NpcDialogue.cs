using System;
using System.Collections.Generic;
using AvventuraTestuale.Conditions;

namespace AvventuraTestuale.Model {
    public class NpcDialogue : Dialogue {

        private NpcID npcID;
        

        public NpcDialogue(NpcID npcId, DialogueID id, string text, params IExitCondition[] exitConditions) : base(id, text, exitConditions) {

            npcID= npcId;

        }

        public NpcID NpcID { get => npcID; }
        
      


        public override bool IsObsolete() {

            if (exitConditions.Length <= 0 && !Player.Instance.HadConversation(npcID, id)) {
                return false;
            }


            foreach (IExitCondition condition in exitConditions) {
                if (!condition.IsConditionMet())
                    return false;
            }

            return true;
        }
    }
}

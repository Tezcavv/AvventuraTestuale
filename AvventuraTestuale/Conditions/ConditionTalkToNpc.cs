using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Conditions {
    public class ConditionTalkToNpc : IExitCondition {

        private NpcID npcID;
        private DialogueID dialogueID;

        public ConditionTalkToNpc(NpcID npcId,DialogueID dialogueToWaitFor) {
            npcID = npcId;
        }

        public bool IsConditionMet() {
            return Player.Instance.HadConversation(npcID, dialogueID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {
    public class Player {


        private static Player instance;
        public static Player Instance {
            get {
                if (instance == null) {
                    instance = new Player();
                }
                return instance;
            }
        }

        private Dictionary<NpcID, List<DialogueID>> conversationsHad;
        private Dictionary<AmbientID, Dictionary<HotAreaID, int>> hotAreasStatus;
        private Dictionary<ItemID, int> interactedItems;
        private Vector2 currentPosition;



        private Player() {



            conversationsHad = new Dictionary<NpcID, List<DialogueID>>();
            hotAreasStatus = new Dictionary<AmbientID, Dictionary<HotAreaID, int>>();
            interactedItems = new Dictionary<ItemID, int>();
            currentPosition = new Vector2(0, 0);


        }



        public void AddConversation(NpcID npcId,DialogueID dialogueID) {

            if (!conversationsHad.ContainsKey(npcId)) {
                conversationsHad.Add(npcId, new List<DialogueID>() { dialogueID });
                return;
            }

            if (!conversationsHad[npcId].Contains(dialogueID))
                return;

            conversationsHad[npcId].Add(dialogueID);
        }

        public bool HadConversation(NpcID withNpcId,DialogueID dialogueID) {
            if (!conversationsHad.ContainsKey(withNpcId))
                return false;
            if (!conversationsHad[withNpcId].Contains(dialogueID))
                return false;
            return true;
        }

        public Dictionary<AmbientID, Dictionary<HotAreaID, int>> HotAreasStatus { get => hotAreasStatus; }
        public Dictionary<ItemID, int> InteractedItems { get => interactedItems; }
    }
}

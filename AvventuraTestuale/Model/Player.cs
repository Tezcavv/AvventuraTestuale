using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {
    public class Player {


        private static Dictionary<NpcID, List<DialogueID>> conversationsHad = new Dictionary<NpcID, List<DialogueID>>();
        private static Dictionary<HotAreaID, List<DialogueID>> hotAreaInteractionsHad = new Dictionary<HotAreaID, List<DialogueID>>();
        private static List<Item> itemsInInventory= new List<Item>();
        private static Vector2 currentPosition = new Vector2(0, 0);
        private static Ambient currentAmbient;
        public static Ambient CurrentAmbient {
            get {
                if (currentAmbient == null)
                    currentAmbient = Ambient.allAmbients.Find(ambient => ambient.WorldPosition == currentPosition);

              return currentAmbient;
            }
            set { currentAmbient= value;
                currentPosition = value.WorldPosition;  }
        }

        public static void AddConversation(HotAreaID hotAreaId, DialogueID dialogueID) {

            if (!hotAreaInteractionsHad.ContainsKey(hotAreaId)) {
                hotAreaInteractionsHad.Add(hotAreaId, new List<DialogueID>() { dialogueID });
                return;
            }

            if (!hotAreaInteractionsHad[hotAreaId].Contains(dialogueID))
                hotAreaInteractionsHad[hotAreaId].Add(dialogueID);


        }

        public static void AddConversation(NpcID npcId,DialogueID dialogueID) {

            if (!conversationsHad.ContainsKey(npcId)) {
                conversationsHad.Add(npcId, new List<DialogueID>() { dialogueID });
                return;
            }

            if (!conversationsHad[npcId].Contains(dialogueID))
                conversationsHad[npcId].Add(dialogueID);


        }

        public static bool HadConversation(NpcID withNpcId,DialogueID dialogueID) {
            if (!conversationsHad.ContainsKey(withNpcId))
                return false;
            if (!conversationsHad[withNpcId].Contains(dialogueID))
                return false;
            return true;
        }

        public static bool HadConversation(HotAreaID hotAreaID, DialogueID dialogueID) {
            if (!hotAreaInteractionsHad.ContainsKey(hotAreaID))
                return false;
            if (!hotAreaInteractionsHad[hotAreaID].Contains(dialogueID))
                return false;
            return true;
        }

        public static Dictionary<HotAreaID, List<DialogueID>> HotAreaInteractionsHad { get => hotAreaInteractionsHad; }
        public static List<Item> ItemsInInventory { get => itemsInInventory; }
    }
}

using AvventuraTestuale.Conditions;
using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.DialogueActions {
    public class AcquireItem : IDialogueAction {

        ItemID itemID;
        public AcquireItem(ItemID id) {
            itemID = id;
        }
        public void Execute() {
            Item toAdd = Item.allItems.Find(item => item.ItemID == itemID);
            Player.ItemsInInventory.Add(toAdd);
            Program.SlowlyWrite("Hai ottenuto: " + toAdd.Name);
        }
    }
}

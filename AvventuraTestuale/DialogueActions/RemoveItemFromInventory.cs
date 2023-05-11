using AvventuraTestuale.Conditions;
using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.DialogueActions {
    public class RemoveItemFromInventory : IDialogueAction {

        ItemID itemId;

        public RemoveItemFromInventory(ItemID id) {
            itemId = id;
        }

        public void Execute() {
            Item toRemove = Item.allItems.Find(item => item.ItemID == itemId);
            Player.ItemsInInventory.Remove(toRemove);
            Program.SlowlyWrite("Non hai più: " + toRemove.Name);
        }
    }
}

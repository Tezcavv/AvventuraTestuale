using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Conditions {
    public class IsItemInInventoryCondition : IExitCondition {

        private ItemID itemID;
        public IsItemInInventoryCondition(ItemID id) {
            itemID= id;
        }
        public bool IsConditionMet() {
            return Player.ItemsInInventory.Any(item => item.ItemID == itemID);
        }
    }
}

using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Conditions {
    public class ItemIsUsedOnCondition :IExitCondition {


        private ItemID itemID;
        private HotAreaID hotAreaID;
        public ItemIsUsedOnCondition(ItemID itemId, HotAreaID hotAreaId ) {
        
            itemID= itemId;
            hotAreaID= hotAreaId;

        }

        public bool IsConditionMet() {
            return Player.IsItemUsedOnHotArea(itemID, hotAreaID);
        }
    }
}

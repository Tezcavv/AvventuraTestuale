using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {

    public enum ItemID { OGG01,OGG02,OGG03,OGG04,OGG05,OGG06,OGG07,OGG08,OGG09}
    public class Item {

        public static List<Item> allItems = new List<Item>();

        private ItemID itemID;
        private string name;
        private string description;

        public Item(ItemID id, string name, string description) {
            
            itemID = id;
            this.name = name;
            this.description = description;

            allItems.Add(this);
        }

        public string Description => description;
        public string Name => name.ToLower();

        public ItemID ItemID => itemID;



    }
}

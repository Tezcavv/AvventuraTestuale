using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale.Model {

    public enum ItemID { OGG01,OGG02,OGG03,OGG04,OGG05,OGG06,OGG07,OGG08,OGG09}
    public class Item {

        private static Dictionary<ItemID, Item> allItems = new Dictionary<ItemID, Item>();

        private string name;
        private string description;
        private int status;

        public Item(ItemID id, string name, string description) {
            
            this.name = name;
            this.description = description;
            status = 0;

            allItems.Add(id, this);

        }

        public string Description => description;
        public int Status => status;    
        public string Name => name;
        public static Dictionary<ItemID, Item> AllItems => allItems;



    }
}

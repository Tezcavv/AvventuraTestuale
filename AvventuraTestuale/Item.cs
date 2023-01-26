using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class Item {

        private string name;
        private string description;

        public Item(string name, string description) {
            this.name = name;
            this.description = description;
        }

        public string Name {
            get { return name; }
            set { name = value; } 
        }
        
        public string Description {
            get { return description; }
            set { description = value; }
        }

    }
}

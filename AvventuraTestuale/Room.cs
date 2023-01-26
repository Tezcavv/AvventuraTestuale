using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class Room {

        private string name;
        private string description;
        private Vector2 position;
        private List<Npc> npcs;
        private List<Item> items;  


        public Room(string name, string description, Vector2 position) {
            Name = name;
            Description = description;
            Position = position;
            Npcs= new List<Npc>();
            Items = new List<Item>();   
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }
        public Vector2 Position { 
            get { return position; } 
            set { position = value; } 
        }

        public List<Npc> Npcs {
            get { return npcs; }
            set { npcs = value; }
        }

        public List<Item> Items {
            get { return items; }
            set { items = value; }
        }
       
        public void AddItem(Item item) {
            Items.Add(item);
        }

        public Npc GetNpc(string name) {
            foreach (Npc npc in npcs) {
                if (name.Contains(npc.Name.ToLower())) {
                    return npc;
                }
            }
            return null;
        }

        public bool ContainsItem(string itemName) {
            foreach (Item item in items) {
                if(itemName.Contains(item.Name.ToLower())) { 
                    return true;
                }
            }
            return false;
        }

        public Item GetItem(string name) {
            foreach (Item item in items) {
                if (name.Contains(item.Name.ToLower())) {
                    return item;
                }
            }
            return null;
        }

        public bool ContainsNpc(string npcName) {
            foreach (Npc npc in Npcs) {
                if (npcName.Contains(npc.Name.ToLower())) {
                    return true;
                }
            }
            return false;
        }
        public void RemoveItem(Item item) {
            Items.Remove(item);
        }

        public void AddNpc(Npc npc) { 
            Npcs.Add(npc);
        }
        public void RemoveNpc(Npc npc) {
            Npcs.Remove(npc);
        }

        

    }
}

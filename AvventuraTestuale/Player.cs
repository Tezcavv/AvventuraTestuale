using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class Player {

        private static List<Npc> npcsIHaveTalkedTo;
        private static List<Item> itemsIHaveInteractedWith;
        private static List<Room> roomsIHaveExplored;



        private Vector2 position;

        public Player() { 
            position= new Vector2(0,0);
            npcsIHaveTalkedTo= new List<Npc>();
            itemsIHaveInteractedWith= new List<Item>();
        }

        public Player(Vector2 position) {
            Position = position;
        }

        public void Move(Vector2 position) {
            Console.WriteLine("Moving from " + Position.ToString() + " to " + position.ToString());
            Position = position;
            
        }

        public Vector2 Position {
            get { return position; }
            private set { position = value; }
        }

        public static bool HasTalkedToNpc(Npc npc) {
           return npcsIHaveTalkedTo.Contains(npc);
        }

        public static void AddNpcToTalkedList(Npc npc) {
            if (npcsIHaveTalkedTo.Contains(npc)) 
                return;
            
            npcsIHaveTalkedTo.Add(npc);
        }

        public static void AddExploredRoom(Room room) {
            roomsIHaveExplored.Add(room);
        }

        public static bool HasExploredRoom(Room room) {
            return roomsIHaveExplored.Contains(room);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class Player {

        private Vector2 position;

        public Player() { 
            position= new Vector2(0,0);
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
    }
}

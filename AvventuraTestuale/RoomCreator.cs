using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class RoomCreator {



        public static Room FirstRoom() {
            Room room = new Room("Cucina", "la cucina, un posto magico", new Vector2(0, 0));          
            Item item = new Item("Ascia", "Ascia Affilatissima, muy guapa");
            DialogueLine dial1 = new DialogueLine("AAAAAAAAAA", new NoExitCondition());
            Dialogue dialogo = new Dialogue(dial1);
            room.AddNpc(new Npc("GIBBY", dialogo));
            room.AddItem(item);
            return room;
        }

        public static Room SecondRoom() {
            Room room = new Room("Sala", "La sala da pranzo", new Vector2(0, 1));
            DialogueLine dial1 = new DialogueLine("Ma te, nell'orata all'acqua calda, ce li metti i pachino?", new NoExitCondition());
            DialogueLine dial2 = new DialogueLine("Parla con quello in prima room", new TalkedToNpcExitCondition(Program.GetNpc("GIBBY")));
            Dialogue dialogo1 = new Dialogue(new List<DialogueLine> { dial2, dial1 });
            room.AddNpc(new Npc("Biascica", dialogo1));
            room.AddItem(new Item("Fotocamera", "non ne so niente di fotocamere"));
            room.AddItem(new Item("Martellone", "è enorme ommioddio non usarlo sulla macchina fotografica la spaccheresti fortissimo"));
            return room;
        }


        public static Room ThirdRoom() {
            Room room = new Room("Bagno", "Il pensatoio", new Vector2(0, 2));
            // room3.AddNpc(new Npc("Man Living in my walls", " . . . "));
            room.AddItem(new Item("Gabinetto", "ci fai i bisogni"));
            room.AddItem(new Item("Lavandino", "se non sei all'UNIFI lo usi per lavarti le mani"));

            return room;
        }


    }
}

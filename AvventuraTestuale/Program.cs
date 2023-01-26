using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvventuraTestuale {

 
    internal class Program {

        const string GAME_TITLE = "Gatito";
        const int INITIAL_PAUSE_MILLIS = 200;
        const int LETTER_PAUSE_MILLIS = 30;
        const string ESAMINA = "esamina";
        const string VAI = "vai";
        const string USA = "usa";
        const string PARLA = "parla";
        const string HELP = "help";
        const string GUARDATI_INTORNO = "guardati";

        //al fine di velocizzare il mio scrivere, ho creato funzioni con nomi più corti
        //Leggere la documentazione delle funzioni per maggiori informazioni

        private static List<string> azioni;
        private static List<Room> rooms;
        private static Player player;

        public static Room CurrentRoom {
            get {
               return GetRoom(player.Position);
            }
        }


        static void Initialize() {
            Console.Title= GAME_TITLE;

            azioni = new List<string>() {
            ESAMINA,
            VAI,
            USA,
            PARLA,
            HELP,
            GUARDATI_INTORNO
            };
            rooms= new List<Room>();

            player = new Player();

            Room room = new Room("Cucina", "la cucina, un posto magico", new Vector2(0, 0));
            Npc npc = new Npc("Carlo", "hello there");
            Item item = new Item("Ascia","Ascia Affilatissima, muy guapa");
            room.AddNpc(npc);
            room.AddItem(item);

            Room room2 = new Room("Sala","La sala da pranzo",new Vector2(0,1));
            room2.AddNpc(new Npc("Biascica","Ma te, nell'orata all'acqua calda, ce li metti i pachino?"));
            room2.AddItem(new Item("Fotocamera","non ne so niente di fotocamere"));
            room2.AddItem(new Item("Martellone","è enorme ommioddio non usarlo sulla macchina fotografica la spaccheresti fortissimo"));

            Room room3 = new Room("Bagno", "Il pensatoio", new Vector2(0, 2));
            room3.AddNpc(new Npc("Man Living in my walls", " . . . "));
            room3.AddItem(new Item("Gabinetto","ci fai i bisogni"));
            room3.AddItem(new Item("Lavandino", "se non sei all'UNIFI lo usi per lavarti le mani"));

            Room room4 = new Room("Camera da letto", "roooonf...fifififi", new Vector2(1, 1));

            rooms.Add(room);
            rooms.Add(room2);
            rooms.Add(room3); 

           
        }

        static void Main(string[] args) {

            Initialize();
            while (true) {
                AskAction();
            }

           
        }

        /// <summary>
        /// Azione che chiederà all'utente di specificare una azione e un bersaglio
        /// </summary>
        private static void AskAction() {
            string input = Read().ToLower();
            string[] wordsFound = input.Split(' ');

            if(wordsFound.Length < 1) {
                SlowlyWrite("Serve una azione");
                AskAction();
                return;
            }



            string firstWord = wordsFound[0];
            string lastWord = input.Substring(firstWord.Length);
            //lastWord -> il target avrà anche le parole in eccesso dopo il comando
            

            if (!azioni.Contains(firstWord)){
                SlowlyWrite("Azione non trovata");
                AskAction();
                return;
            }


           // SlowlyWrite("Azione trovata");
            Execute(firstWord, lastWord);
            return;
           
        }

        /// <summary>
        /// Funzionamento identico a Console.ReadLine
        /// </summary>
        /// <returns></returns>
        private static string Read() {
            return Console.ReadLine();
        }

        /// <summary>
        /// Funzionamento identico a Console.WriteLine
        /// </summary>
        /// <param name="o"></param>
        private static void Write(Object o) {
            Console.WriteLine(o.ToString());
        }


        /// <summary>
        /// Scrive ogni carattere della stringa con una piccola pausa
        /// tra una lettera e l'altra , ciò dopo una pausa iniziale di 500 millisecondi
        /// </summary>
        private static void SlowlyWrite(string s) {
            SlowlyWrite(s, LETTER_PAUSE_MILLIS);
        }

        /// <summary>
        /// Scrive ogni carattere della stringa con una pausa di X secondi
        /// </summary>
        /// <param name="initialPauseMillis">la pausa iniziale prima di scrivere</param>
        private static void SlowlyWrite(string s, int pauseMillis) {
            Thread.Sleep(INITIAL_PAUSE_MILLIS); 
            foreach (char ch in s) {
                Console.Write(ch); 
                Thread.Sleep(pauseMillis);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// esegue l'azione sul target
        /// </summary>
        /// <param name="action">l'azione da eseguire</param>
        /// <param name="target">il bersaglio dell'azione</param>
        private static void Execute(string action, string target) {
            //Write("Azione " + action + " , Bersaglio: " + target);

            switch (action) {
                case ESAMINA:
                    HandleExamine(target);
                    break;
                case USA:
                    Write("stai usando " + target);
                    break;
                case PARLA:
                    HandleTalk(target);
                    break;
                case VAI:
                    HandleMovement(target);
                    break;
                case GUARDATI_INTORNO:
                    HandleLookAround();
                    break;
                case HELP:
                    HandleHelp();
                    break;
            }
        }

        private static void HandleLookAround() {

            SlowlyWrite(CurrentRoom.Description);
            SlowlyWrite("Nella stanza vedi:");
            foreach (Npc npc in CurrentRoom.Npcs) {
                SlowlyWrite("- " + npc.Name);
            }
            foreach(Item item in CurrentRoom.Items) {
                SlowlyWrite("* " + item.Name);
            }

            List<Room> adjacentRooms = GetAdjacentRooms(CurrentRoom);

            foreach(Room room in adjacentRooms) {
                SlowlyWrite("\nLe stanze vicine sono:");
                SlowlyWrite(room.Name);
            }
        }



        public static void HandleTalk(string npcName) {

            if (string.IsNullOrWhiteSpace(npcName)) {
                SlowlyWrite("Serve un bersaglio dell'azione");
                return;
            }

            if (!CurrentRoom.ContainsNpc(npcName)){
                SlowlyWrite("Bersaglio non esiste");
                return;
            }

            SlowlyWrite(CurrentRoom.GetNpc(npcName).Dialogue);

        }

        private static void HandleExamine(string target) {

            if (string.IsNullOrEmpty(target)) {
                SlowlyWrite("Serve un bersaglio per questa azione");
                return;
            }

            if (!CurrentRoom.ContainsItem(target)) {
                SlowlyWrite("Oggetto non trovato nella stanza");
                return;
            }

            SlowlyWrite(CurrentRoom.GetItem(target).Description);



        }

        private static void HandleHelp() {

            Write("Comandi Disponibili:");
            foreach(string command in azioni) {
                Write("- " + command);
            }
            
        }

        /// <summary>
        /// Movimento secondo i 4 punti cardinali
        /// </summary>
        /// <param name="target">stringa contenente nord, est, ovest, sud </param>
        public static void HandleMovement(string target) {

            if (string.IsNullOrWhiteSpace(target)) {
                SlowlyWrite("Serve un bersaglio dell'azione");
                return;
            }

            Vector2 currentPosition = player.Position;
            Vector2 targetPosition = player.Position;
            if (target == "") {
                SlowlyWrite("Inserisci una direzione");
                return;
            }
            switch (target) {
                case string a when a.Contains("nord"):
                    targetPosition = player.Position + new Vector2(0, 1);
                    break;
                case string a when a.Contains("sud"):
                    targetPosition = player.Position + new Vector2(0, -1);
                    break;
                case string a when a.Contains("ovest"):                    
                    targetPosition = player.Position + new Vector2(-1, 0);
                    break;
                case string a when a.Contains("est"):                   
                    targetPosition = player.Position + new Vector2(1, 0);
                    break;
                          
            }

            if(targetPosition == currentPosition || !IsThereRoom(targetPosition)) {
                SlowlyWrite("Non c'è nessuna stanza in quella direzione");
                return;
            }

            player.Move(targetPosition);

        }


        public static Room GetRoom(Vector2 position) {
            foreach(Room room in rooms) {
                if(room.Position == position) {
                    return room;
                }
            }
            return null;
        }

        public static bool IsThereRoom(Vector2 pos) {
            foreach(Room room in rooms) {
                if(room.Position == pos) {
                    return true;
                }
            }
            return false;
        }

        public static List<Room> GetAdjacentRooms(Room room) {
            List<Room> adjacentLists = new List<Room>();
            int currentX = Convert.ToInt32(room.Position.X);
            int currentY = Convert.ToInt32(room.Position.Y);

            for(int offsetX = -1; offsetX <= 1; offsetX ++) {
                for(int offsetY = -1; offsetY <= 1; offsetY++) {

                    Vector2 positionToTest = new Vector2(currentX + offsetX, currentY + offsetY);
                    if (IsThereRoom(positionToTest)) {
                        adjacentLists.Add(GetRoom(positionToTest));
                    }
                }
            }

            //tra i risultati c'è anche quella corrente
            adjacentLists.Remove(CurrentRoom);

            return adjacentLists;
        }


    }
}

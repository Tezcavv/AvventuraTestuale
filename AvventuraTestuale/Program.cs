using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;


//Sei già stato rickrollato dagli altri?
//Se sì: scusa

namespace AvventuraTestuale {

    public enum Action { PARLA, USA, ESAMINA, GUARDATI_INTORNO, VAI, AIUTO, INVENTARIO, ESCI }
    public enum Direction { NORD, EST, OVEST, SUD }
    public class Program {



        const string GAME_TITLE = "Gatito";
        public const string COMMAND_NOT_VALID = "Comando non valido";
        const string TARGET_NOT_FOUND = "Bersaglio non trovato";
        const string TARGET_NEEDED = "Serve un Bersaglio";
        const string ITEM_NOT_IN_INVENTORY = "Oggetto da usare non valido / non in inventario";
        const int INITIAL_PAUSE_MILLIS = 200;
        const int LETTER_PAUSE_MILLIS = 30;


        private static Dictionary<string, Action> commands = new Dictionary<string, Action>() {
            { "parla",Action.PARLA},
            { "usa",Action.USA},
            { "esamina",Action.ESAMINA},
            { "guardati",Action.GUARDATI_INTORNO},
            { "vai",Action.VAI},
            { "inventario",Action.INVENTARIO},
            { "aiuto",Action.AIUTO},
            { "esci",Action.ESCI}
        };
        private static bool gameIsRunning = true;

        #region WorldInit
        static void CreateWorld() {

            WorldFactory.CreateAmbients();

        }
        #endregion

        #region Console I/O

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

        public static void SlowlyWrite(string s) {
            SlowlyWrite(s, LETTER_PAUSE_MILLIS);
        }
        public static void SlowlyWrite(string s, int pauseMillis) {
            Thread.Sleep(INITIAL_PAUSE_MILLIS);
            foreach (char ch in s) {
                Console.Write(ch);
                Thread.Sleep(pauseMillis);
            }
            Console.WriteLine();
        }

        #endregion

        static void Main(string[] args) { 

            Console.Title = GAME_TITLE;
            CreateWorld();
            while (gameIsRunning) {
                Write(""); 
                AskAction();
            }

        }


        private static void AskAction() {
            string input = Read().ToLower();
            string[] wordsFound = input.Split(' ');

            if (wordsFound.Length < 1) {
                SlowlyWrite("Serve una azione");
                return;
            }

            string firstWord = wordsFound[0].Trim();
            string target = input.Substring(firstWord.Length);

            if (!commands.ContainsKey(firstWord)) {
                SlowlyWrite(COMMAND_NOT_VALID);
                return;
            }

            HandleCommand(commands[firstWord], target);
        }
        #region Every Command Handler
        private static void HandleCommand(Action action, string target) {

            switch (action) {
                case Action.PARLA: HandleTalk(target); break;
                case Action.ESAMINA: HandleExamine(target); break;
                case Action.AIUTO: HandleHelp();break;
                case Action.GUARDATI_INTORNO: {
                    HandleLookAround();
                    PrintActiveCloseAmbients();
                    break;
                }
                case Action.INVENTARIO: PrintInventory();break;
                case Action.VAI: 
                    GoTowards(target);
                    break;
                case Action.ESCI: Environment.Exit(0);break;
                case Action.USA: HandleUse(target); break;
            }


        }

        private static void HandleUse(string itemAndTarget) {

            List<string> words = itemAndTarget.Trim().Split(' ').ToList();
            words.ForEach(word => word.Trim());

            string item = words[0];

            if (!Player.ItemsInInventory.Any(i => i.Name == item)) {
                SlowlyWrite(ITEM_NOT_IN_INVENTORY);
                return;
            }

            if (words.Count < 2) {
                SlowlyWrite(TARGET_NEEDED);
                return;
            }
            
            string target = words[words.Count - 1];

            if (!Player.CurrentAmbient.HotAreas.Any(hotArea => hotArea.Name == target)) {
                SlowlyWrite(TARGET_NOT_FOUND);
                return;
            }

            HotArea hh = Player.CurrentAmbient.HotAreas.Find(i => i.Name == target);
            Item it = Player.ItemsInInventory.Find(i => i.Name == item);

            Player.UseItemOnHotArea(it.ItemID, hh.Id);
            hh.PlayDialogue(Action.USA);
            

        


        }

        private static void GoTowards(string target) {

            Dictionary<string, Ambient> availableAmbients = GetActiveCloseAmbients();

            if (availableAmbients.Count == 0) {
                SlowlyWrite("Non ci sono altri posti in cui andare");
                return;
            }

            if (target.Contains("nord") && availableAmbients.ContainsKey("nord")) {
                Player.CurrentAmbient = availableAmbients["nord"];                
            }
            else if (target.Contains("ovest") && availableAmbients.ContainsKey("ovest")) {
                Player.CurrentAmbient = availableAmbients["ovest"];              
            }
            else if (target.Contains("est") && availableAmbients.ContainsKey("est")) {
                Player.CurrentAmbient = availableAmbients["est"];
              
            }
            else if (target.Contains("sud") && availableAmbients.ContainsKey("sud")) {
                Player.CurrentAmbient = availableAmbients["sud"];
            }

            Console.Clear();
            Thread.Sleep(500);
            HandleLookAround();
            PrintActiveCloseAmbients();
        }

        private static void PrintInventory() {
            SlowlyWrite("Inventario:");
            Player.ItemsInInventory.ForEach(item => SlowlyWrite("  " + item.Name));

        }

        private static void PrintActiveCloseAmbients() {
            Dictionary<string, Ambient> availableAmbients = GetActiveCloseAmbients();
            if (availableAmbients.Count == 0) {
                SlowlyWrite("Non ci sono altri posti in cui andare");
                return;
            }

            SlowlyWrite("\nPuoi andare a:");
            foreach(string dir in availableAmbients.Keys) {
                SlowlyWrite(" " + dir.ToUpper() + " - " + availableAmbients[dir].Name);
            }
        }

        private static Dictionary<string, Ambient> GetActiveCloseAmbients() {

            Dictionary<string, Ambient> adjacentAmbients = new Dictionary<string, Ambient>();

            Vector2 ovest = Player.CurrentAmbient.WorldPosition + new Vector2(-1, 0);
            Vector2 est = Player.CurrentAmbient.WorldPosition + new Vector2(1, 0);
            Vector2 nord = Player.CurrentAmbient.WorldPosition + new Vector2(0, 1);
            Vector2 sud = Player.CurrentAmbient.WorldPosition + new Vector2(0,-1);

            foreach(Ambient ambient in Ambient.allAmbients) {

                if (!ambient.IsActive)
                    continue;

                if (ambient.WorldPosition == ovest)
                    adjacentAmbients["ovest"] = ambient;
                else if (ambient.WorldPosition == est)
                    adjacentAmbients["est"] = ambient;
                else if (ambient.WorldPosition == nord)
                    adjacentAmbients["nord"] = ambient;
                else if(ambient.WorldPosition == sud)
                    adjacentAmbients["sud"] = ambient;
            }

            return adjacentAmbients;
        }

       



        private static void HandleLookAround() {
            SlowlyWrite(Player.CurrentAmbient.Name.ToUpper() + " - " + Player.CurrentAmbient.Description);
            SlowlyWrite("Ti guardi attorno, vedi:");
            foreach(IExaminable examinable in Player.CurrentAmbient.Examinables) {
                SlowlyWrite(examinable.Name);
            }
        }

        private static void HandleHelp() {
            string result = "Comandi: " +
                            "\n PARLA : richiede bersaglio" +
                            "\n ESAMINA : richiede bersaglio" +
                            "\n USA : richiede oggetto e bersaglio" +
                            "\n GUARDATI / GUARDATI INTORNO : esamina la stanza in cui ti trovi" +
                            "\n INVENTARIO: mostra gli oggetti in tuo possesso" +
                            "\n VAI : richiede una direzione" +
                            "\n ESCI: esci dal gioco";
            Write(result);
        }

        private static void HandleExamine(string target) {
            if(!Player.CurrentAmbient.Examinables.Any( obj => target.Contains(obj.Name))) {
                SlowlyWrite(TARGET_NOT_FOUND);
                return;
            }
            string description = Player.CurrentAmbient.Examinables.Find(x => target.Contains(x.Name)).Description;
            SlowlyWrite(description);
        }

        private static void HandleTalk(string target) {

            List<string> npcName = target.Trim().Split(' ').ToList();
            if (!Player.CurrentAmbient.Npcs.Any(npc => npc.Name.ToLower().Equals(npcName[npcName.Count-1]))) {
                SlowlyWrite(TARGET_NOT_FOUND);
                return;
            }
            Player.CurrentAmbient.Npcs.Find(npc => npc.Name.ToLower().Equals(npcName[npcName.Count - 1])).PlayDialogue();
        }

        #endregion

    }
}

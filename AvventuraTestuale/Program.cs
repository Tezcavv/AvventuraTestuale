using AvventuraTestuale.Conditions;
using AvventuraTestuale.DialogueActions;
using AvventuraTestuale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvventuraTestuale {

    public enum Action { USA }
    public class Program {


        const string GAME_TITLE = "Gatito";
        const int INITIAL_PAUSE_MILLIS = 200;
        const int LETTER_PAUSE_MILLIS = 30;
        
        static Ambient ambient;
        static Ambient ambient2;
        static Player player;

        static void InitializeStuff() {
            Dialogue dial1 = new NpcDialogue(NpcID.PG01,DialogueID.DIAL01, "CIAO");
            Dialogue dial2 = new NpcDialogue(NpcID.PG01, DialogueID.DIAL02, "Come va?");
            dial2.AddAction(new UnlockAmbient(AmbientID.AM02));
            Npc npc = new Npc(NpcID.PG01, "Giorgio", new List<Dialogue>() { dial1, dial2 });
            ambient = new Ambient(new Vector2(0, 0), AmbientID.AM01, "casa", "casa tua",null,new List<Npc>() { npc });
            ambient2 = new Ambient(new Vector2(1, 0), AmbientID.AM02, "fuori", "fuori", null, null);
            ambient2.SetActive(false);
            player = Player.Instance;

        }
        static void Main(string[] args) {
            InitializeStuff();
            while (true) {
                Write(""); //
                AskAction();
            }

        }


        private static void AskAction() {
            string input = Read().ToLower();
            string[] wordsFound = input.Split(' ');

            if (wordsFound.Length < 1) {
                SlowlyWrite("Serve una azione");
                AskAction();
                return;
            }



            string firstWord = wordsFound[0].Trim();
            string lastWord = input.Substring(firstWord.Length);
            //lastWord -> il target avrà anche le parole in eccesso dopo il comando


            if (firstWord == "parla") {
                SlowlyWrite(Npc.allNpcs[NpcID.PG01].GetDialogue());
               // SlowlyWrite("Azione non trovata");
                //AskAction();
                return;
            }

            if()


            // SlowlyWrite("Azione trovata");
            AskAction();
            return;

        }


        #region Console Writing Logic

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

        private static void SlowlyWrite(string s) {
            SlowlyWrite(s, LETTER_PAUSE_MILLIS);
        }
        private static void SlowlyWrite(string s, int pauseMillis) {
            Thread.Sleep(INITIAL_PAUSE_MILLIS);
            foreach (char ch in s) {
                Console.Write(ch);
                Thread.Sleep(pauseMillis);
            }
            Console.WriteLine();
        }
    }
    #endregion
}

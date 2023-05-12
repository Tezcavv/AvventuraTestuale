using AvventuraTestuale.Conditions;
using AvventuraTestuale.DialogueActions;
using AvventuraTestuale.Model;
using System.Numerics;

namespace AvventuraTestuale {
    public class WorldFactory {


        public static void CreateAmbients() {

            Ambient amb1 = new Ambient(new Vector2(0, 0), AmbientID.AM01, "Vicolo", "Un vicolo piccolo e buio");
            Ambient amb2 = new Ambient(new Vector2(0, -1), AmbientID.AM02, "Piazza", "Il luogo di ritrovo preferito di ogni cittadino");
            Ambient amb3 = new Ambient(new Vector2(1, -1), AmbientID.AM03, "Mercato", "Dove gli affari migliori vengono svolti");
            Ambient amb4 = new Ambient(new Vector2(-1, -1), AmbientID.AM04, "Fogne", "Stai attento ai ratti!");
            amb4.SetActive(false);
            Ambient amb5 = new Ambient(new Vector2(0, 1), AmbientID.AM05, "Parco", "Il cuore verde del paese");
            amb5.SetActive(false);

            HotArea hh1 = new HotArea(HotAreaID.HH01, "Fontanella");
            Dialogue d1 = new Dialogue(DialogueID.DIAL01, "La fontanella non funziona, per usarla serve inserire la manovella",new ItemIsUsedOnCondition(ItemID.OGG01,HotAreaID.HH01));
            Dialogue d3 = new Dialogue(DialogueID.DIAL03, "La fontanella funziona ma non hai nulla per raccogliere l'acqua", new ItemIsUsedOnCondition(ItemID.OGG02, HotAreaID.HH01));
            Dialogue d5 = new Dialogue(DialogueID.DIAL05, "La fontanella funziona ma non hai più motivo di usarla", new LastDialogue());
            hh1.AddDialogue(Action.ESAMINA, d1,d3,d5);
            Dialogue d2 = new Dialogue(DialogueID.DIAL02, "Hai messo la manovella e adesso l'acqua è tornata a scorrere", new RemoveItemFromInventory(ItemID.OGG01));
            d2.AddExitCondition(new ItemIsUsedOnCondition(ItemID.OGG02, HotAreaID.HH01));
            Dialogue d4 = new Dialogue(DialogueID.DIAL04, "Azioni la fontanella, metti il secchio sotto il getto d'acqua \nil secchio è ora pieno", new EndGame());
            hh1.AddDialogue(Action.USA, d2,d4);

            Npc npc1 = new Npc(NpcID.PG01, "Vagabondo", "un vagabondo dall'aria calma, non sembra avere brutte intenzioni");
            Dialogue d6 = new Dialogue(DialogueID.DIAL06, "Tieni:", new AcquireItem(ItemID.OGG01));
            Dialogue d7 = new Dialogue(DialogueID.DIAL07, "Beh, tieni anche questo:", new AcquireItem(ItemID.OGG02));
            d7.AddExitCondition(new LastDialogue());
            npc1.AddDialogues(d6, d7);

            amb1.AddNpcs(npc1);
            amb1.AddHotAreas(hh1);

            Item i1 = new Item(ItemID.OGG01, "Manovella", "una manovella");
            Item i2 = new Item(ItemID.OGG02, "Secchio", "--");
            

        }

    }
}

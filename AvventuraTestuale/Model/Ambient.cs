using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

namespace AvventuraTestuale.Model {

    public enum AmbientID { AM01,AM02,AM03,AM04,AM05,AM06}
    public enum Direction { SUD, EST, OVEST, NORD }
    public class Ambient {

        public static Dictionary<AmbientID,Ambient>  allAmbients = new Dictionary<AmbientID, Ambient> ();

        private Vector2 worldPosition;
        private Dictionary<HotAreaID, HotArea> hotAreas;
        private Dictionary<NpcID, Npc> npcs;
        private Dictionary<Direction, Ambient> adjacentAmbients;
        private string name;
        private string description;
        private bool isActive;


        public Ambient(Vector2 worldPosition, AmbientID id, string name, string description, List<HotArea> hotAreas = null, List<Npc> npcs = null) {
            this.worldPosition = worldPosition;
            this.name = name;
            this.description = description;

            this.hotAreas = new Dictionary<HotAreaID, HotArea>();
            this.npcs = new Dictionary<NpcID, Npc>();
            
            hotAreas?.ForEach(hotArea => { this.hotAreas[hotArea.Id] = hotArea; });
            npcs?.ForEach(npc => { this.npcs[npc.Id] = npc; });

            allAmbients.Add(id, this);

        }

        public Vector2 WorldPosition => worldPosition;
        public Dictionary<HotAreaID, HotArea> HotAreas => hotAreas;
        public Dictionary<NpcID, Npc> Npcs => npcs;
        public Dictionary<Direction, Ambient> AdjacentAmbients => adjacentAmbients;
        public string Name => name;
        public string Description => description;
        public bool IsActive => isActive;

        public void SetActive(bool active) {
            isActive = active;
        }

        //private void SetUp




    }
}

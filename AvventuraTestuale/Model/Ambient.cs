using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;

namespace AvventuraTestuale.Model {

    public enum AmbientID { AM01,AM02,AM03,AM04,AM05,AM06}
    public class Ambient {

        public static List<Ambient> allAmbients = new List<Ambient>();

        private AmbientID ambientID;
        private Vector2 worldPosition;
        private List<HotArea> hotAreas;
        private List<Npc> npcs;
        private List<IExaminable> examinables;
        private string name;
        private string description;
        private bool isActive;


        public Ambient(Vector2 worldPosition, AmbientID id, string name, string description, List<Npc> npcs, List<HotArea> hotAreas) {
            ambientID = id;
            this.worldPosition = worldPosition;
            this.name = name;
            this.description = description;

            this.npcs = npcs;
            this.hotAreas = hotAreas;
            examinables = new List<IExaminable>();
            examinables.AddRange(npcs);
            examinables.AddRange(hotAreas);

            allAmbients.Add(this);

        }


        public Ambient(Vector2 worldPosition, AmbientID id, string name, string description) : this(worldPosition, id, name, description, new List<Npc>(), new List<HotArea>()) { }
        public Ambient(Vector2 worldPosition, AmbientID id, string name, string description, List<Npc> npcs) : this(worldPosition, id, name, description, npcs, new List<HotArea>()) { }
        public Ambient(Vector2 worldPosition, AmbientID id, string name, string description, List<HotArea> hotAreas) : this(worldPosition, id, name, description, new List<Npc>(), hotAreas) { }


        public void AddNpcs(params Npc[] npcs) {
            npcs.ToList().ForEach(npc =>{  this.npcs.Add(npc);
                                           this.examinables.Add(npc); }) ;
            
        }



        public Vector2 WorldPosition => worldPosition;
        public List<HotArea> HotAreas => hotAreas;
        public List<Npc> Npcs => npcs;
        public string Name => name;
        public string Description => description;
        public bool IsActive => isActive;
        public AmbientID AmbientID => ambientID;
        public List<IExaminable> Examinables => examinables;

        public void SetActive(bool active) {
            isActive = active;
        }

        //private void SetUp




    }
}

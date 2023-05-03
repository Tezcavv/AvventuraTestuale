using System.Collections.Generic;
using System.Numerics;

namespace AvventuraTestuale.Model {

    public enum AmbientID { AM01,AM02,AM03,AM04,AM05,AM06}
    public class Ambient {

        private static Dictionary<AmbientID,Ambient>  allAmbients = new Dictionary<AmbientID, Ambient> ();

        private Vector2 worldPosition;
        private Dictionary<HotAreaID, HotArea> hotAreas;
        private string name;
        private string description;


        public Ambient(Vector2 worldPosition, AmbientID id, string name, string description, params HotArea[] hotAreas) {
            this.worldPosition = worldPosition;
            this.name= name;
            this.description = description;

            allAmbients.Add(id, this);

        }


        public Vector2 WorldPosition => worldPosition;
        public string Name => name;
        public string Description => description;
        public Dictionary<HotAreaID,HotArea> HotAreas => hotAreas;

    }
}

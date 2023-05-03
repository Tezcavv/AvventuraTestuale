using System.Collections.Generic;
using System.Numerics;

namespace AvventuraTestuale.Model {

    public enum AmbientID { AM01,AM02,AM03,AM04,AM05,AM06}
    public class Ambient {

        public static Dictionary<AmbientID,Ambient>  allAmbients = new Dictionary<AmbientID, Ambient> ();

        private Vector2 worldPosition;
        

    }
}

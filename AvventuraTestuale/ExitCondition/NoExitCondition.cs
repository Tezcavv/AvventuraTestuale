using AvventuraTestuale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraTestuale {
    public class NoExitCondition : ExitCondition {

        //NO exit condition, appunto
        public override bool IsValid() {
            return false;
        }
    }
}

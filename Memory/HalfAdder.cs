using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class HalfAdder : TwoInputGate
    {
        public Wire CarryOutput { get; private set; }

        //your code here


        public HalfAdder()
        {
            //your code here

        }


        public override string ToString()
        {
            return "HA " + Input1.Value + "," + Input2.Value + " -> " + Output.Value + " (C" + CarryOutput + ")";
        }

        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class FullAdder : TwoInputGate
    {
        public Wire CarryInput { get; private set; }
        public Wire CarryOutput { get; private set; }

        //your code here


        public FullAdder()
        {
            CarryInput = new Wire();
            //your code here

        }


        public override string ToString()
        {
            return Input1.Value + "+" + Input2.Value + " (C" + CarryInput.Value + ") = " + Output.Value + " (C" + CarryOutput.Value + ")";
        }

        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}

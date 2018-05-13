using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class XorGate : TwoInputGate
    {
        //your code here

        public XorGate()
        {
            //your code here
        }

        public override string ToString()
        {
            return "Xor " + Input1.Value + "," + Input2.Value + " -> " + Output.Value;
        }



        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}

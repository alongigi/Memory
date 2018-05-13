using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class BitwiseAndGate : BitwiseTwoInputGate
    {
        //your code here

        public BitwiseAndGate(int iSize)
            : base(iSize)
        {
            //your code here
        }


        public override string ToString()
        {
            return "And " + Input1 + ", " + Input2 + " -> " + Output;
        }

        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}

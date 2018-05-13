using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class BitwiseOrGate : BitwiseTwoInputGate
    {
        //your code here

        public BitwiseOrGate(int iSize)
            : base(iSize)
        {
            //your code here
        }


        public override string ToString()
        {
            return "Or " + Input1 + ", " + Input2 + " -> " + Output;
        }

        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}

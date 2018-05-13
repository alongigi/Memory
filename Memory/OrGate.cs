using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class OrGate : TwoInputGate
    {
        //your code here 

        public OrGate()
        {
            //your code here 

        }


        public override string ToString()
        {
            return "Or " + Input1.Value + "," + Input2.Value + " -> " + Output.Value;
        }

        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }

}

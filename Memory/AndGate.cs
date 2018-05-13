using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    
    class AndGate : TwoInputGate
    {
        //your code here

        public AndGate()
        {
            //your code here

        }

        //an implementation of the ToString method is called, e.g. when we use Console.WriteLine(and)
        //this is very helpful during debugging
        public override string ToString()
        {
            return "And " + Input1.Value + "," + Input2.Value + " -> " + Output.Value;
        }

        //this method is used to test the gate. 
        //we simply check whether the truth table is properly implemented.
        public override bool TestGate()
        {
            //your code here
            throw new NotImplementedException();
        }
    }
}

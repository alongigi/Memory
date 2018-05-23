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
            XorGate xor = new XorGate();
            AndGate and = new AndGate();
            xor.ConnectInput1(Input1);
            xor.ConnectInput2(Input2);
            and.ConnectInput1(Input2);
            and.ConnectInput2(Input1);
            Output = xor.Output;
            CarryOutput = and.Output;
        }


        public override string ToString()
        {
            return "HA " + Input1.Value + "," + Input2.Value + " -> " + Output.Value + " (C" + CarryOutput + ")";
        }

        public override bool TestGate()
        {
            Input1.Value = 0;
            Input2.Value = 0;
            if ((Output.Value != 0) && (CarryOutput.Value != 0))
                return false;
            Input1.Value = 0;
            Input2.Value = 1;
            if ((Output.Value != 1) && (CarryOutput.Value != 0))
                return false;
            Input1.Value = 1;
            Input2.Value = 0;
            if ((Output.Value != 1) && (CarryOutput.Value != 0))
                return false;
            Input1.Value = 1;
            Input2.Value = 1;
            if ((Output.Value != 0) && (CarryOutput.Value != 1))
                return false;

            return true;
        }
    }
}

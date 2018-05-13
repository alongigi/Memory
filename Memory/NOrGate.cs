using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    //this gate is given to you fully implemented - you only have to use it in your code
    class NOrGate : TwoInputGate, Component
    {
        public static int NOR_GATES = 0;
        public static int NOR_COMPUTE = 0;

        public NOrGate()
        {
            NOR_GATES++;
        }

        public override string ToString()
        {
            return "NOr " + Input1.Value + "," + Input2.Value + " -> " + Output.Value;
        }


        public override bool TestGate()
        {
            Input1.Value = 0;
            Input2.Value = 0;
            
            if (Output.Value != 1)
                return false;

            Input1.Value = 0;
            Input2.Value = 1;
            
            if (Output.Value != 0)
                return false;

            Input1.Value = 1;
            Input2.Value = 0;
            
            if (Output.Value != 0)
                return false;

            Input1.Value = 1;
            Input2.Value = 1;
            
            if (Output.Value != 0)
                return false;
            return true;
        }

        #region Component Members

        public void Compute()
        {
            NOR_COMPUTE++;
            if (Input1.Value == 1 || Input2.Value == 1)
                Output.Value = 0;
            else
                Output.Value = 1;
        }

        #endregion
    }
}

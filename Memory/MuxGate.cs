using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class MuxGate : TwoInputGate
    {
        public Wire ControlInput { get; private set; }
        //your code here


        public MuxGate()
        {
            ControlInput = new Wire();

            //your code here

        }

        public void ConnectControl(Wire wControl)
        {
            ControlInput.ConnectInput(wControl);
        }


        public override string ToString()
        {
            return "Mux " + Input1.Value + "," + Input2.Value + ",C" + ControlInput.Value + " -> " + Output.Value;
        }



        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}

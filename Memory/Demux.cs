using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class Demux : Gate
    {
        public Wire Output1 { get; private set; }
        public Wire Output2 { get; private set; }
        public Wire Input { get; private set; }
        public Wire Control { get; private set; }

        //your code here

        public Demux()
        {
            Input = new Wire();
            //your code here
        }

        public void ConnectControl(Wire wControl)
        {
            Control.ConnectInput(wControl);
        }
        public void ConnectInput(Wire wInput)
        {
            Input.ConnectInput(wInput);
        }



        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}

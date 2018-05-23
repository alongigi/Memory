using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class SingleBitRegister : Gate
    {
 
        public Wire Input { get; private set; }
        public Wire Output { get; private set; }
        public Wire Load { get; private set; }
        private MuxGate mux;
        private DFlipFlopGate ff;
        public SingleBitRegister()
        {
            
            Input = new Wire();
            Load = new Wire();
            Output = new Wire();
            mux = new MuxGate();
            ff = new DFlipFlopGate();
            mux.ConnectControl(Load);
            mux.ConnectInput1(ff.Output);
            mux.ConnectInput2(Input);
            ff.ConnectInput(mux.Output);
            Output.ConnectInput(ff.Output);



        }

        public void ConnectInput(Wire wInput)
        {
            Input.ConnectInput(wInput);
        }

      

        public void ConnectLoad(Wire wLoad)
        {
            Load.ConnectInput(wLoad);
        }


        public override bool TestGate()
        {
            Input.Value = 0;
            Load.Value = 1;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Value != 0)
                return false;

            Input.Value = 1;
            Load.Value = 1;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Value != 1)
                return false;

            Input.Value = 0;
            Load.Value = 0;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Value != 1)
                return false;

            Input.Value = 0;
            Load.Value = 1;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Value != 0)
                return false;

            return true;



        }
    }
}

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
            Control = new Wire();

            //init
            AndGate and1 = new AndGate();
            AndGate and2 = new AndGate();
            NotGate not = new NotGate();
            and1.ConnectInput1(Input);
            and2.ConnectInput2(Input);
            not.ConnectInput(Control);
            and1.ConnectInput2(not.Output);
            and2.ConnectInput1(Control);
            Output1 = and1.Output;
            Output2 = and2.Output;







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
            Input.Value = 0;
            Control.Value = 0;
            if ((Output1.Value != 0) &&(Output2.Value!=0))
                return false;
            Input.Value = 0;
            Control.Value = 1;
            if ((Output1.Value != 0) && (Output2.Value != 0)) 
                return false;
            Input.Value = 1;
            Control.Value = 0;
            if ((Output1.Value != 1) && (Output2.Value != 0)) 
                return false;
            Input.Value = 1;
            Control.Value = 1;
            if ((Output1.Value != 0) && (Output2.Value != 1)) 
                return false;

            return true;





        }
    }
}

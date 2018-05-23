using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class MuxGate : TwoInputGate
    {
        public Wire ControlInput { get; private set; }
        private AndGate and1;
        private AndGate and2;
        private OrGate or;
        private NotGate not;




        public MuxGate()
        {//init
            ControlInput = new Wire();
            Wire a = new Wire();
            Wire b = new Wire();
            and1 = new AndGate();
            and2 = new AndGate();
            or = new OrGate();
            not = new NotGate();

            //connect
            or.ConnectInput1(and1.Output);
            or.ConnectInput2(and2.Output);
            and1.ConnectInput1(ControlInput);
            and1.ConnectInput2(b);
            and2.ConnectInput1(not.Output);
            not.ConnectInput(ControlInput);
            and2.ConnectInput2(a);











 /*           or.ConnectInput1(and1.Output);
            or.ConnectInput2(and2.Output);
            and1.ConnectInput1(ControlInput);
            and1.ConnectInput1(b);
            not.ConnectInput(ControlInput);
            and2.ConnectInput1(not.Output);
        and2.ConnectInput2(a);              */ 
            //input\output
            Input1 = a;
            Input2 = b;
            Output = or.Output;
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
            Input1.Value = 0;
            Input2.Value = 0;
            ControlInput.Value = 0;
            if (Output.Value != 0)
                return false;
            Input1.Value = 0;
            Input2.Value = 1;
            ControlInput.Value = 0;
            if (Output.Value != 0)
                return false;
            Input1.Value = 1;
            Input2.Value = 0;
            ControlInput.Value = 0;
            if (Output.Value != 1)
                return false;
            Input1.Value = 1;
            Input2.Value = 1;
            ControlInput.Value = 0;
            if (Output.Value != 1)
                return false;

            Input1.Value = 0;
            Input2.Value = 0;
            ControlInput.Value = 1;
            if (Output.Value != 0)
                return false;
            Input1.Value = 0;
            Input2.Value = 1;
            ControlInput.Value = 1;
            if (Output.Value != 1)
                return false;
            Input1.Value = 1;
            Input2.Value = 0;
            ControlInput.Value = 1;
            if (Output.Value != 0)
                return false;
            Input1.Value = 1;
            Input2.Value = 1;
            ControlInput.Value = 1;
            if (Output.Value != 1)
                return false;



           
            
            
            return true;
        }
    }
}

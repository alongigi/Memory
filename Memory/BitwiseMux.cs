using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class BitwiseMux : BitwiseTwoInputGate
    {
        public Wire ControlInput { get; private set; }

        //your code here

        public BitwiseMux(int iSize)
            : base(iSize)
        {

            ControlInput = new Wire();
            MuxGate[] mux = new MuxGate[iSize];
            for (int i = 0; i < iSize; i++)
            {
                mux[i] = new MuxGate();
                mux[i].ConnectInput1(Input1[i]);
                mux[i].ConnectInput2(Input2[i]);
                mux[i].ConnectControl(ControlInput);
                Output[i].ConnectInput(mux[i].Output);
            }
            //your code here

        }

        public void ConnectControl(Wire wControl)
        {
            ControlInput.ConnectInput(wControl);
        }



        public override string ToString()
        {
            return "Mux " + Input1 + "," + Input2 + ",C" + ControlInput.Value + " -> " + Output;
        }




        public override bool TestGate()
        {
            WireSet ws1 = new WireSet(3);
            Wire w1 = new Wire();
            w1.Value = 0;
            Wire w2 = new Wire();
            w2.Value = 0; 
            Wire w3 = new Wire();
            w3.Value = 0;

            WireSet ws2 = new WireSet(3);
            Wire w4 = new Wire();
            w4.Value = 1;
            Wire w5 = new Wire();
            w5.Value = 1;
            Wire w6 = new Wire();
            w6.Value = 1;

            this.ControlInput.Value=0;

            Input1[0].ConnectInput(w1);
            Input1[1].ConnectInput(w2);
            Input1[2].ConnectInput(w3);
            Input2[0].ConnectInput(w4);
            Input2[1].ConnectInput(w5);
            Input2[2].ConnectInput(w6);
            Console.WriteLine("TESTING And..Is it true?    : "+ this.ToString());
            return true;
                ;
        }

    }
}

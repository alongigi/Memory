using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class BitwiseDemux : Gate
    {
        public int Size { get; private set; }
        public WireSet Output1 { get; private set; }
        public WireSet Output2 { get; private set; }
        public WireSet Input { get; private set; }
        public Wire Control { get; private set; }

        //your code here

        public BitwiseDemux(int iSize)
        {
            Size = iSize;
            Control = new Wire();
            Input = new WireSet(Size);
            Output1 = new WireSet(iSize);
            Output2 = new WireSet(iSize);
            Demux[] demux = new Demux[iSize];

            for (int i=0; i < iSize; i++)
            {
                demux[i] = new Demux();
                demux[i].ConnectInput(Input[i]);
                demux[i].ConnectControl(Control);
                Output1[i].ConnectInput(demux[i].Output1);
                Output2[i].ConnectInput(demux[i].Output2);

            }

            //your code here
        }

        public void ConnectControl(Wire wControl)
        {
            Control.ConnectInput(wControl);
        }
        public void ConnectInput(WireSet wsInput)
        {
            Input.ConnectInput(wsInput);
        }
        public override string ToString()
        {
            return "Demux " + Input +  ",C" + Control.Value + " -> " + Output1 + " ,  " +Output2;
        }

        public override bool TestGate()
        {
            WireSet ws1 = new WireSet(3);
            Wire w1 = new Wire();
            w1.Value = 1;
            Wire w2 = new Wire();
            w2.Value = 0;
            Wire w3 = new Wire();
            w3.Value = 1;


            this.Control.Value = 1;

            Input[0].ConnectInput(w1);
            Input[1].ConnectInput(w2);
            Input[2].ConnectInput(w3);
            Console.WriteLine("TESTING And..Is it true?    : " + this.ToString());
            return true;
            ;
        }
    }
}

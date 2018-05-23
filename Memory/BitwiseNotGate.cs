using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class BitwiseNotGate : Gate
    {
        public WireSet Input { get; private set; }
        public WireSet Output { get; private set; }
        public int Size { get; private set; }

        //your code here

        public BitwiseNotGate(int iSize)
        {
            Size = iSize;
            Input = new WireSet(Size);
            Output = new WireSet(Size);
            NotGate[] not = new NotGate[iSize];
            for (int i = 0; i < iSize; i++)
            {
                not[i] = new NotGate();
                not[i].ConnectInput(Input[i]);
                Output[i].ConnectInput(not[i].Output);
            }
        }

        public void ConnectInput(WireSet ws)
        {
            Input.ConnectInput(ws);
        }


        public override string ToString()
        {
            return "Not " + Input + " -> " + Output;
        }

        public override bool TestGate()
        {
            WireSet ws1 = new WireSet(3);
            Wire w1 = new Wire();
            w1.Value = 0;
            Wire w2 = new Wire();
            w2.Value = 1;
            Wire w3 = new Wire();
            w3.Value = 1;

            Input[0].ConnectInput(w1);
            Input[1].ConnectInput(w2);
            Input[2].ConnectInput(w3);
            Console.WriteLine("TESTING Not..Is it true?    : " + this.ToString());
            return true;




        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class MultiBitAdder : Gate
    {
        public int Size { get; private set; }
        public WireSet Input1 { get; private set; }
        public WireSet Input2 { get; private set; }
        public WireSet Output { get; private set; }
        public Wire Overflow { get; private set; }


        public MultiBitAdder(int iSize)
        {
            Size = iSize;
            Input1 = new WireSet(Size);
            Input2 = new WireSet(Size);
            Output = new WireSet(Size);
            Overflow = new Wire();
            FullAdder[] fa = new FullAdder[Size];
            for (int i = 0; i < Size; i++)
            {   if (fa[i]==null)
                   fa[i] = new FullAdder();
                fa[i].ConnectInput1(Input1[i]);
                fa[i].ConnectInput2(Input2[i]);
                Output[i].ConnectInput(fa[i].Output);
                if (i == Size - 1)
                    Overflow.ConnectInput(fa[i].CarryOutput);
                else{
                    fa[i+1] = new FullAdder();
                fa[i + 1].CarryInput.ConnectInput(fa[i].CarryOutput);  }

            }
        }

        public override string ToString()
        {
            return Input1 + "(" + Input1.Get2sComplement() + ")" + " + " + Input2 + "(" + Input2.Get2sComplement() + ")" + " = " + Output + "(" + Output.Get2sComplement() + ")";
        }

        public void ConnectInput1(WireSet wInput)
        {
            Input1.ConnectInput(wInput);
        }
        public void ConnectInput2(WireSet wInput)
        {
            Input2.ConnectInput(wInput);
        }


        public override bool TestGate()
        {
            WireSet ws1 = new WireSet(5);
            WireSet ws2 = new WireSet(5);
            ws1.SetValue(5);
            ws2.Set2sComplement(7);
            this.ConnectInput1(ws1);
            this.ConnectInput2(ws2);
            Console.WriteLine("TESTING Or..Is it true?    :MULTI_BIT_ADDER " + this.ToString());
            return true;

        }
    }
}

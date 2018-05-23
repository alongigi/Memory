using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class MultiBitRegister : Gate
    {
        public WireSet Input { get; private set; }
        public WireSet Output { get; private set; }
        public Wire Load { get; private set; }
        public int Size { get; private set; }


        public MultiBitRegister(int iSize)
        {
            Size = iSize;
            Input = new WireSet(Size);
            Output = new WireSet(Size);
            Load = new Wire();
            SingleBitRegister[] reg=new SingleBitRegister[iSize];
            for(int i=0;i<iSize;i++){
                reg[i] = new SingleBitRegister();
                reg[i].ConnectInput(Input[i]);
                reg[i].ConnectLoad(Load);
                Output[i].ConnectInput(reg[i].Output);
            }

        }

        public void ConnectInput(WireSet wsInput)
        {
            Input.ConnectInput(wsInput);
        }

        
        public override string ToString()
        {
            return Output.ToString();
        }


        public override bool TestGate()
        {
            Input.Set2sComplement(5);
            Load.Value = 1;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Get2sComplement() != 5)
                return false;

            Input.Set2sComplement(8);
            Load.Value = 1;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Get2sComplement() != 8)
                return false;

            Input.Set2sComplement(4);
            Load.Value = 0;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Get2sComplement() != 8)
                return false;

            Input.Set2sComplement(3);
            Load.Value = 1;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Get2sComplement() != 3)
                return false;

            return true;



        }
    }
}

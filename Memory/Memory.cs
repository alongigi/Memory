using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class Memory : SequentialGate
    {
        public int AddressSize { get; private set; }
        public int WordSize { get; private set; }

        public WireSet Input { get; private set; }
        public WireSet Output { get; private set; }
        public WireSet Address { get; private set; }
        public Wire Load { get; private set; }
        private BitwiseMultiwayDemux demux;
        private BitwiseMultiwayMux mux;
        private WireSet loadWs;
        //your code here

        public Memory(int iAddressSize, int iWordSize)
        {
            AddressSize = iAddressSize;
            WordSize = iWordSize;

            Input = new WireSet(WordSize);
            Output = new WireSet(WordSize);
            Address = new WireSet(AddressSize);
            Load = new Wire();

            //your code here
            demux = new BitwiseMultiwayDemux(1, iAddressSize);
            mux = new BitwiseMultiwayMux(iWordSize, iAddressSize);
            loadWs = new WireSet(1);
            loadWs[0].ConnectInput(Load);
            demux.ConnectControl(Address);
            demux.ConnectInput(loadWs);
            MultiBitRegister[] mbr = new MultiBitRegister[(int)Math.Pow(2, iAddressSize)];
            for (int i = 0; i < mbr.Length; i++)
            {
                mbr[i] = new MultiBitRegister(iWordSize);
                mbr[i].ConnectInput(Input);
                mbr[i].Load.ConnectInput(demux.Outputs[i][0]);
                mux.Inputs[i].ConnectInput(mbr[i].Output);
            }
            mux.ConnectControl(Address);
            Output.ConnectInput(mux.Output);


        }

        public void ConnectInput(WireSet wsInput)
        {
            Input.ConnectInput(wsInput);
        }
        public void ConnectAddress(WireSet wsAddress)
        {
            Address.ConnectInput(wsAddress);
        }


        public override void OnClockUp()
        {
        }

        public override void OnClockDown()
        {
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override bool TestGate()
        {
            Input.Set2sComplement(22);
            Address.Set2sComplement(4);
            Load.Value = 1;
            Clock.ClockDown();
            Clock.ClockUp();
            Load.Value=0;
            if (Output.Get2sComplement() != 22)
                return false;
            Input.Set2sComplement(11);
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Get2sComplement() != 22)
                return false;
            Load.Value = 1;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Get2sComplement() != 11)
                return false;

            Load.Value = 0;
            Address.SetValue(7);
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Get2sComplement() != 0)
                return false;
            Load.Value = 1;
            if (Output.Get2sComplement() != 0)
                return false;
            Clock.ClockDown();
            Clock.ClockUp();
            if (Output.Get2sComplement() != 11)
                return false;
            
            return true;

        }
    }
}

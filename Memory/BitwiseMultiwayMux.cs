using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Components
{
    class BitwiseMultiwayMux : Gate
    {
        public int Size { get; private set; }
        public int ControlBits { get; private set; }
        public WireSet Output { get; private set; }
        public WireSet Control { get; private set; }
        public WireSet[] Inputs { get; private set; }

        //your code here

        public BitwiseMultiwayMux(int iSize, int cControlBits)
        {
            Size = iSize;
            Output = new WireSet(Size);
            Control = new WireSet(cControlBits);
            Inputs = new WireSet[(int)Math.Pow(2, cControlBits)];
            
            for (int i = 0; i < Inputs.Length; i++)
            {
                Inputs[i] = new WireSet(Size);
                
            }

            BitwiseMux[] mux = new BitwiseMux[(int)Math.Pow(2, cControlBits) - 1];
            WireSet[] wires = new WireSet[(int)Math.Pow(2, cControlBits)];
            int wiresLength = wires.Length;
            int currentMux = 0;
            int toSave = 0;
            int currentControl = 0;
            for(int i=0;i<wires.Length;i++){
                wires[i] = Inputs[i];
            }

            while (wiresLength >= 2)
            {
                for (int i = 0; i < wiresLength; i = i + 2)
                {
                    mux[currentMux] = new BitwiseMux(Size);
                    mux[currentMux].ConnectInput1(wires[i]);
                    mux[currentMux].ConnectInput2(wires[i+1]);
                    mux[currentMux].ConnectControl(Control[currentControl]);
                    wires[toSave] = mux[currentMux].Output;
                    toSave++;
                    currentMux++;
                }
                wiresLength = wiresLength / 2;
                toSave = 0;
                currentControl++;
            }
            Output.ConnectInput(mux[currentMux - 1].Output);

        }


        public void ConnectInput(int i, WireSet wsInput)
        {
            Inputs[i].ConnectInput(wsInput);
        }
        public void ConnectControl(WireSet wsControl)
        {
            Control.ConnectInput(wsControl);
        }



        public override bool TestGate()
        {

            Console.WriteLine("TESTING MULTIMUX..Is it true?    : " + this.Output.ToString());
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class BitwiseMultiwayDemux : Gate
    {
        public int Size { get; private set; }
        public int ControlBits { get; private set; }
        public WireSet Input { get; private set; }
        public WireSet Control { get; private set; }
        public WireSet[] Outputs { get; private set; }

        //your code here

        public BitwiseMultiwayDemux(int iSize, int cControlBits)
        {
            Size = iSize;
            Input = new WireSet(Size);
            Control = new WireSet(cControlBits);
            Outputs = new WireSet[(int)Math.Pow(2, cControlBits)];
            for (int i = 0; i < Outputs.Length; i++)
            {
                Outputs[i] = new WireSet(Size);
            }

            BitwiseDemux[] demux = new BitwiseDemux[(int)Math.Pow(2, cControlBits) - 1];

            
            int currentDemux = 0;
            int maxDemux = 0;
            int currentControl = cControlBits-1;
            demux[0] = new BitwiseDemux(Size);
            demux[0].ConnectInput(Input);
            demux[0].ConnectControl(Control[currentControl]);
            currentControl--;

            for (int i=1;i<cControlBits;i++)
            {
                while (currentDemux<=maxDemux){
                    
                    demux[currentDemux * 2 + 1] = new BitwiseDemux(Size);
                    demux[currentDemux*2+1].ConnectInput(demux[currentDemux].Output1);
                    demux[currentDemux*2+1].ConnectControl(Control[currentControl]);
                    demux[currentDemux * 2 + 2] = new BitwiseDemux(Size);
                    demux[currentDemux*2+2].ConnectInput(demux[currentDemux].Output2);
                    demux[currentDemux*2+2].ConnectControl(Control[currentControl]);

                    currentDemux++;
                }
                

                maxDemux+=(int)Math.Pow(2,i);
                currentControl--;
            }





            int c = 0;
            for (int j=((demux.Length+1)/2)-1;j<demux.Length;j++){
                Outputs[c].ConnectInput(demux[j].Output1);
                Outputs[c+1].ConnectInput(demux[j].Output2);



                c=c+2;
            }
         }
        public void ConnectInput(WireSet wsInput)
        {
            Input.ConnectInput(wsInput);
        }
        public void ConnectControl(WireSet wsControl)
        {
            Control.ConnectInput(wsControl);
        }


        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}
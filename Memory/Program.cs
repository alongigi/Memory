using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class Program
    {
         static void Main(string[] args)
        {

            AndGate and = new AndGate();
            OrGate or = new OrGate();
            XorGate xor = new XorGate();
            MuxGate mux = new MuxGate();
            Demux demux = new Demux();
            HalfAdder ha = new HalfAdder();
            FullAdder fa = new FullAdder();
            if (!and.TestGate())
                Console.WriteLine("bugbug");


            
            Console.WriteLine("done And");
           
             if (!or.TestGate())
                Console.WriteLine("bugbug");



            Console.WriteLine("done Or");

            if (!xor.TestGate())
                Console.WriteLine("bugbug");



            Console.WriteLine("done Xor");

            if (!mux.TestGate())
                Console.WriteLine("bugbug");



            Console.WriteLine("done Mux");

            if (!demux.TestGate())
                Console.WriteLine("bugbug");



            Console.WriteLine("done Demux");

            if (!ha.TestGate())
                Console.WriteLine("bugbug");



            Console.WriteLine("done HalfAdder");

            if (!fa.TestGate())
                Console.WriteLine("bugbug");



            Console.WriteLine("done FullAdder");



            WireSet num = new WireSet(4);
            num.SetValue(6);
            Console.WriteLine(num.ToString());
            Console.WriteLine(num.GetValue());

            Console.WriteLine("trying 2's complement");
            WireSet num2 = new WireSet(4);

            num2.Set2sComplement(6);
            Console.WriteLine(num2.Get2sComplement());
            WireSet num3 = new WireSet(4);

            num3.Set2sComplement(-2);
            Console.WriteLine(num3.Get2sComplement());

             BitwiseAndGate BWAnd=new BitwiseAndGate(3);
             BWAnd.TestGate();

             BitwiseNotGate BWNot = new BitwiseNotGate(3);
             BWNot.TestGate();

             BitwiseOrGate BWOr = new BitwiseOrGate(3);
             BWOr.TestGate();

             BitwiseMux BWMux = new BitwiseMux(3);
             BWMux.TestGate();

             BitwiseDemux BWDemux = new BitwiseDemux(3);
             BWDemux.TestGate();

             MultiBitAndGate multiAnd = new MultiBitAndGate(3);
             multiAnd.TestGate();

             MultiBitAdder multiAdd = new MultiBitAdder(5);
             multiAdd.TestGate();

                         BitwiseMultiwayMux multimux = new BitwiseMultiwayMux(8,2);
                         WireSet[] inp=new WireSet[4];
                         inp[0] = new WireSet(8);
                         inp[0].Set2sComplement(1);
                         multimux.ConnectInput(0,inp[0]);
                         inp[1] = new WireSet(8);
                         inp[1].Set2sComplement(2);
                         multimux.ConnectInput(1, inp[1]);
                         inp[2] = new WireSet(8);
                         inp[2].Set2sComplement(3);
                         multimux.ConnectInput(2, inp[2]);
                         inp[3] = new WireSet(8);
                         inp[3].Set2sComplement(4);
                         multimux.ConnectInput(3, inp[3]);
                        


                         WireSet control = new WireSet(2);
                         control.Set2sComplement(3);
                         multimux.ConnectControl(control);

                         multimux.TestGate();

            BitwiseMultiwayDemux multidemux = new BitwiseMultiwayDemux(8, 1);


            ALU alu = new ALU(16);
            alu.TestGate();



            SingleBitRegister sbr = new SingleBitRegister();
            if (sbr.TestGate())
                Console.WriteLine("sbr IS OK");

            MultiBitRegister mbr = new MultiBitRegister(8);
            if (mbr.TestGate())
                Console.WriteLine("mbr IS OK");

            Memory mem = new Memory(3, 6);
            if (mem.TestGate())
                Console.WriteLine("mem IS OK");

             


            Console.ReadLine();
        }
    }
}

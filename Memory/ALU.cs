using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class ALU : Gate
    {
        public WireSet InputX { get; private set; }
        public WireSet InputY { get; private set; }
        public WireSet Output { get; private set; }

        public Wire ZeroX { get; private set; }
        public Wire ZeroY { get; private set; }
        public Wire NotX { get; private set; }
        public Wire NotY { get; private set; }
        public Wire F { get; private set; }
        public Wire NotOutput { get; private set; }

        public Wire Zero { get; private set; }
        public Wire Negative { get; private set; }

        public int Size { get; private set; }

        private BitwiseMux muxZx;
        private BitwiseMux muxZy;
        private BitwiseMux muxNx;
        private BitwiseMux muxNy;
        private BitwiseMux muxF;
        private BitwiseMux muxNo;
        private BitwiseNotGate notNx;
        private BitwiseNotGate notNy;
        private BitwiseNotGate notNo;
        private BitwiseAndGate andF;
        private MultiBitAdder adderF;
        private WireSet wireX0;
        private WireSet wireY0;
        private BitwiseNotGate isZeroNot;
        private MultiBitAndGate isZeroMultiAnd;


        public ALU(int iSize)
        {
            Size = iSize;
            InputX = new WireSet(Size);
            InputY = new WireSet(Size);
            ZeroX = new Wire();
            ZeroY = new Wire();
            NotX = new Wire();
            NotY = new Wire();
            F = new Wire();
            NotOutput = new Wire();
            Negative = new Wire();            
            Zero = new Wire();
            Output = new WireSet(iSize);

            muxZx = new BitwiseMux(iSize);
            muxZy=new BitwiseMux(iSize);
            muxNx=new BitwiseMux(iSize);
            muxNy=new BitwiseMux(iSize);
            muxF=new BitwiseMux(iSize);
            muxNo=new BitwiseMux(iSize);
            notNx=new BitwiseNotGate(iSize);
            notNy=new BitwiseNotGate(iSize);
            notNo=new BitwiseNotGate(iSize);
            andF=new BitwiseAndGate(iSize);
            adderF=new MultiBitAdder(iSize);
            wireX0 = new WireSet(iSize);
            wireX0.Set2sComplement(0);
            wireY0 = new WireSet(iSize);
            wireY0.Set2sComplement(0);
            isZeroNot = new BitwiseNotGate(iSize);
            isZeroMultiAnd = new MultiBitAndGate(iSize);

            muxZx.ConnectInput1(InputX);
            muxZx.ConnectInput2(wireX0);
            muxZx.ConnectControl(ZeroX);
            muxNx.ConnectInput1(muxZx.Output);
            notNx.ConnectInput(muxZx.Output);
            muxNx.ConnectInput2(notNx.Output);
            muxNx.ConnectControl(NotX);
            andF.ConnectInput1(muxNx.Output);
            adderF.ConnectInput1(muxNx.Output);

            muxZy.ConnectInput1(InputY);
            muxZy.ConnectInput2(wireY0);
            muxZy.ConnectControl(ZeroY);
            muxNy.ConnectInput1(muxZy.Output);
            notNy.ConnectInput(muxZy.Output);
            muxNy.ConnectInput2(notNy.Output);
            muxNy.ConnectControl(NotY);
            andF.ConnectInput2(muxNy.Output);
            adderF.ConnectInput2(muxNy.Output);
            //now from muxF
            muxF.ConnectInput1(andF.Output);
            muxF.ConnectInput2(adderF.Output);
            muxF.ConnectControl(F);
            muxNo.ConnectInput1(muxF.Output);
            notNo.ConnectInput(muxF.Output);
            muxNo.ConnectInput2(notNo.Output);
            muxNo.ConnectControl(NotOutput);
            Output.ConnectInput(muxNo.Output);
            Negative.ConnectInput(muxNo.Output[iSize-1]);
            isZeroNot.ConnectInput(muxNo.Output);
            isZeroMultiAnd.ConnectInput(isZeroNot.Output);
            Zero.ConnectInput(isZeroMultiAnd.Output);





        }

        public override bool TestGate()
        {
            Console.WriteLine("TESTING FOR X=5, Y=3");
            //1
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 1;
            NotX.Value = 0;
            ZeroY.Value = 1;
            NotY.Value = 0;
            F.Value = 1;
            NotOutput.Value = 0;
            Console.WriteLine("Case 1: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");
            //2
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 1;
            NotX.Value = 1;
            ZeroY.Value = 1;
            NotY.Value = 1;
            F.Value = 1;
            NotOutput.Value = 1;
            Console.WriteLine("Case 2: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //3
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 1;
            NotX.Value = 1;
            ZeroY.Value = 1;
            NotY.Value = 0;
            F.Value = 1;
            NotOutput.Value = 0;
            Console.WriteLine("Case 3: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //4
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 0;
            ZeroY.Value = 1;
            NotY.Value = 1;
            F.Value = 0;
            NotOutput.Value = 0;
            Console.WriteLine("Case 4: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //5
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 1;
            NotX.Value = 1;
            ZeroY.Value = 0;
            NotY.Value = 0;
            F.Value = 0;
            NotOutput.Value = 0;
            Console.WriteLine("Case 5: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //6
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 0;
            ZeroY.Value = 1;
            NotY.Value = 1;
            F.Value = 0;
            NotOutput.Value = 1;
            Console.WriteLine("Case 6: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //7
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 1;
            NotX.Value = 1;
            ZeroY.Value = 0;
            NotY.Value = 0;
            F.Value = 0;
            NotOutput.Value = 1;
            Console.WriteLine("Case 7: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //8
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 0;
            ZeroY.Value = 1;
            NotY.Value = 1;
            F.Value = 1;
            NotOutput.Value = 1;
            Console.WriteLine("Case 8: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //9
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 1;
            NotX.Value = 1;
            ZeroY.Value = 0;
            NotY.Value = 0;
            F.Value = 1;
            NotOutput.Value = 1;
            Console.WriteLine("Case 9: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //10
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 1;
            ZeroY.Value = 1;
            NotY.Value = 1;
            F.Value = 1;
            NotOutput.Value = 1;
            Console.WriteLine("Case 10: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //11
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 1;
            NotX.Value = 1;
            ZeroY.Value = 0;
            NotY.Value = 1;
            F.Value = 1;
            NotOutput.Value = 1;
            Console.WriteLine("Case 11: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //12
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 0;
            ZeroY.Value = 1;
            NotY.Value = 1;
            F.Value = 1;
            NotOutput.Value = 0;
            Console.WriteLine("Case 12: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //13
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 1;
            NotX.Value = 1;
            ZeroY.Value = 0;
            NotY.Value = 0;
            F.Value = 1;
            NotOutput.Value = 0;
            Console.WriteLine("Case 13: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //14
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 0;
            ZeroY.Value = 0;
            NotY.Value = 0;
            F.Value = 1;
            NotOutput.Value = 0;
            Console.WriteLine("Case 14: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //15
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 1;
            ZeroY.Value = 0;
            NotY.Value = 0;
            F.Value = 1;
            NotOutput.Value = 1;
            Console.WriteLine("Case 15: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //16
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 0;
            ZeroY.Value = 0;
            NotY.Value = 1;
            F.Value = 1;
            NotOutput.Value = 1;
            Console.WriteLine("Case 16: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //17
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 0;
            ZeroY.Value = 0;
            NotY.Value = 0;
            F.Value = 0;
            NotOutput.Value = 0;
            Console.WriteLine("Case 17: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            //18
            InputX.Set2sComplement(5);
            InputY.Set2sComplement(5);
            ZeroX.Value = 0;
            NotX.Value = 1;
            ZeroY.Value = 0;
            NotY.Value = 1;
            F.Value = 0;
            NotOutput.Value = 1;
            Console.WriteLine("Case 18: " + Output.Get2sComplement());
            Console.WriteLine("Negative?: " + Negative.Value);
            Console.WriteLine("Zero?: " + Zero.Value);
            Console.WriteLine("");

            return true;
            //    throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class XorGate : TwoInputGate
    {
        //A XOR B = (A ^ ~B)U(~A ^ B)
        private NotGate m_gNot1;
        private NotGate m_gNot2;
        private AndGate m_gAnd1;
        private AndGate m_gAnd2;
        private OrGate m_gOr;
        
        public XorGate()
        {
            //init the gates
            Wire wire1 = new Wire();//for A, first side
            Wire wire2 = new Wire();//for B, second side
            m_gNot1 = new NotGate();//for B, first side
            m_gNot2 = new NotGate();//for A, second side
            m_gAnd1 = new AndGate();//first side
            m_gAnd2 = new AndGate();//second side
            m_gOr = new OrGate();
            //connect the gates
            m_gOr.ConnectInput1(m_gAnd1.Output);
            m_gOr.ConnectInput2(m_gAnd2.Output);
            m_gAnd1.ConnectInput1(wire1);
            m_gNot1.ConnectInput(wire2);
            m_gAnd1.ConnectInput2(m_gNot1.Output);
            m_gNot2.ConnectInput(wire1);
            m_gAnd2.ConnectInput1(m_gNot2.Output);
            m_gAnd2.ConnectInput2(wire2);
            //set the inputs and the output of the or gate
            Output = m_gOr.Output;
            Input1 = wire1;
            Input2 = wire2;
            







        }

        public override string ToString()
        {
            return "Xor " + Input1.Value + "," + Input2.Value + " -> " + Output.Value;
        }



        public override bool TestGate()
        {
            Input1.Value = 0;
            Input2.Value = 0;
            if (Output.Value != 0)
                return false;
            Input1.Value = 0;
            Input2.Value = 1;
            if (Output.Value != 1)
                return false;
            Input1.Value = 1;
            Input2.Value = 0;
            if (Output.Value != 1)
                return false;
            Input1.Value = 1;
            Input2.Value = 1;
            if (Output.Value != 0)
                return false;
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class OrGate : TwoInputGate
    {
        //  (A U B) = ~(~A ^ ~B) 
        private NotGate m_gNot1;
        private NotGate m_gNot2;
        private NotGate m_gNot3;
        private AndGate m_gAnd;

        public OrGate()
        {
            //init the gates
            m_gNot1 = new NotGate();//outside the parentheses
            m_gNot2 = new NotGate();//a
            m_gNot3 = new NotGate();//b
            m_gAnd = new AndGate();
            //connect the gates
            m_gAnd.ConnectInput1(m_gNot2.Output);
            m_gAnd.ConnectInput2(m_gNot3.Output);
            m_gNot1.ConnectInput(m_gAnd.Output);
            //set the inputs and the output of the or gate
            Output = m_gNot1.Output;
            Input1 = m_gNot2.Input;
            Input2 = m_gNot3.Input;


            
        }


        public override string ToString()
        {
            return "Or " + Input1.Value + "," + Input2.Value + " -> " + Output.Value;
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
            if (Output.Value != 1)
                return false;
            return true;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class MultiBitAndGate : MultiBitGate
    {
        //your code here

        public MultiBitAndGate(int iInputCount)
            : base(iInputCount)
       {

            AndGate[] and = new AndGate[iInputCount - 1]; // reminder - make the first one outside the for loop
            and[0] = new AndGate();
            and[0].ConnectInput1(m_wsInput[0]);//assuming there are at least two bits
            and[0].ConnectInput2(m_wsInput[1]);

            for (int i = 1; i < iInputCount-1 ; i++)
            {
                and[i] = new AndGate();
                and[i].ConnectInput1(and[i-1].Output);
                and[i].ConnectInput2(m_wsInput[i + 1]);


            }
            Output.ConnectInput(and[iInputCount - 2].Output);
        }

        

        public override bool TestGate()
        {
            m_wsInput.SetValue(6);
            Console.WriteLine("TESTING MultiAnd..Is it true?    : " + this.m_wsInput.ToString()+"  --> "+Output);

            return true;
        }
    }
}

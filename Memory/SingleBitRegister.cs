using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    class SingleBitRegister : Gate
    {
 
        public Wire Input { get; private set; }
        public Wire Output { get; private set; }
        public Wire Load { get; private set; }

        public SingleBitRegister()
        {
            
            Input = new Wire();
            Load = new Wire();
            //your code here 

        }

        public void ConnectInput(Wire wInput)
        {
            Input.ConnectInput(wInput);
        }

      

        public void ConnectLoad(Wire wLoad)
        {
            Load.ConnectInput(wLoad);
        }


        public override bool TestGate()
        {
            throw new NotImplementedException();
        }
    }
}

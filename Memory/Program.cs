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
            if (!and.TestGate())
                Console.WriteLine("bugbug");

            WireSet ws = new WireSet(4);
            ws[0].Value = 1;

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}

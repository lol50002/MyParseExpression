using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string lol = Console.ReadLine();
            MyTree str = MyTree.parsexpression(lol);
            Console.WriteLine(str.Calculate());
            Dictionary<string, double> res = MyTree.peremenny(lol);
        }
    }
}

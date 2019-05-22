using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace App
{
    public class Program0
    {
        static void Main(string[] args)
        {

            TextEncoder textEncoder = new TextEncoder();
            Console.Out.WriteLine(textEncoder.GetMorseCode(args[0]));


        }
    }
}

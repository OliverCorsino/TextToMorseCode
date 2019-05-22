using Core.Models;
using System;

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

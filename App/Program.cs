﻿using Core.Models;
using System;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Out.WriteLine(string.Empty);
                return;
            }

            foreach (var arg in args)
            {
                if (arg.ToLower().Contains("-b"))
                {
                    Console.Beep();
                }
            }


            TextEncoder textEncoder = new TextEncoder();
            Console.Out.WriteLine(textEncoder.GetMorseCode(args[0]));
        }
    }
}

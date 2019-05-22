using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class TextEncoder
    {
        private static readonly Dictionary<char, string> morseTable = new Dictionary<char, string>()
        {

            {'A' , ". -"},
            {'B' , "- . . ."},
            {'C' , "- . - ."},
            {'D' , "- . ."},
            {'E' , "."},
            {'F' , ". . - ."},
            {'G' , "- - ."},
            {'H' , ". . . ."},
            {'I' , ". ."},
            {'J' , ". - - -"},
            {'K' , "- . -"},
            {'L' , ". - . ."},
            {'M' , "- -"},
            {'N' , "- ."},
            {'O' , "- - -"},
            {'P' , ". - - ."},
            {'Q' , "- - . -"},
            {'R' , ". - ."},
            {'S' , ". . ."},
            {'T' , "-"},
            {'U' , ". . -"},
            {'V' , ". . . -"},
            {'W' , ". - -"},
            {'X' , "- . . -"},
            {'Y' , "- . - -"},
            {'Z' , "- - . ."},
            {'0' , "- - - - -"},
            {'1' , ". - - - -"},
            {'2' , ". . - - -"},
            {'3' , ". . . - -"},
            {'4' , ". . . . -"},
            {'5' , ". . . . ."},
            {'6' , "- . . . ."},
            {'7' , "- - . . ."},
            {'8' , "- - - . ."},
            {'9' , "- - - - ."}
        };
    public string GetMorseCode(string input)
    {
        string value = string.Empty;
        input = input.ToUpper();
        for (int i = 0; i < input.Length; i++)
        {

            value += morseTable[input[i]] + "   ";
        }

        return value.Trim();
    }
}
}
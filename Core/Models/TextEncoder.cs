using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class TextEncoder
    {
        private static readonly Dictionary<char, string> morseTable = new Dictionary<char, string>()
        {
            {'A',".-"},
            {'B',"-..."},
            {'C',"-.-."},
            {'D',"-.."},
            {'E',"."},
            {'F',"..-."},
            {'G',"--."},
            {'H',"...."},
            {'I',".."},
            {'J',".---"},
            {'K',"-.-"},
            {'L',".-.."},
            {'M',"--"},
            {'N',"-."},
            {'O',"---"},
            {'P',".--."},
            {'Q',"--.-"},
            {'R',".-."},
            {'S',"..."},
            {'T',"-"},
            {'U',"..-"},
            {'V',"...-"},
            {'W',".--"},
            {'X',"-..-"},
            {'Y',"-.--"},
            {'Z',"--.."},
            {'0',"-----"},
            {'1',".----"},
            {'2',"..---"},
            {'3',"...--"},
            {'4',"....-"},
            {'5',"....."},
            {'6',"-...."},
            {'7',"--..."},
            {'8',"---.."},
            {'9',"----."}
        };

        public string GetMorseCode(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            if (input.Equals("-b"))
            {
                return string.Empty;
            }

            string[] completeMessage = input.Split(' ');
            string value = string.Empty;
            string message = string.Empty;

            for (int i = 0; i < completeMessage.Length; i++)
            {
                if (completeMessage[i].Equals("-m"))
                {
                    message = completeMessage[i + 1];
                }
                value += morseTable[message[i]] + "|";
            }

            return RemoveLastChar(value);
        }

        public string RemoveLastChar(string Text)
        {
            string StringResult = "";
            try
            {
                StringResult = Text.Remove(Text.Length - 1);
                return StringResult;
            }
            catch (Exception e)
            {
                return StringResult;
            }
        }
    }
}
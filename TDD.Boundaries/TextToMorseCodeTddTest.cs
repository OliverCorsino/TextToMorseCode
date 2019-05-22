using System;
using Core.Models;
using NUnit.Framework;

namespace TDD.Boundaries
{
    [TestFixture]
    public class TextToMorseCodeTddTest
    {
        [TestCase("E", ".")]
        [TestCase("SOS", ". . .   - - -   . . .")]
        [TestCase("HOLA", ". . . .   - - -   . - . .   . -")]
        [TestCase("HoLa", ". . . .   - - -   . - . .   . -")]
        public void Given_Valid_Input_Should_Pass(string input, string output)
        {
            TextEncoder textEncoder = new TextEncoder();

            Assert.That(output, Is.EqualTo(textEncoder.GetMorseCode(input)));
        }
    }
}

using Core;
using NUnit.Framework;

namespace TDD.Boundaries
{
    [TestFixture]
    public class TextToMorseCodeTddTest
    {
        [Test]
        [TestCase("E", ".")]
        public void Given_Valid_Input_Should_Pass(string input, string output)
        {
            TextEncoder textEncoder = new TextEncoder();

            Assert.That(output, Is.EqualTo(textEncoder.GetMorseCode(input)));
        }
    }
}

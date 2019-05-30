using Core.Models;
using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace TDD.Boundaries
{
    [TestFixture]
    public class TextToMorseCodeTddTest
    {

        private static readonly string CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        [TestCase("E", ".")]
        [TestCase("SOS", "...|---|...")]
        [TestCase("HOLA", "....|---|.-..|.-")]
        [TestCase("HoLa", "....|---|.-..|.-")]
        public void Given_Valid_Input_Should_Pass(string input, string output)
        {
            TextEncoder textEncoder = new TextEncoder();

            Assert.That(output, Is.EqualTo(textEncoder.GetMorseCode(input)));
        }

        [Test]
        public void Given_No_Parameter_Input_Should_Pass()
        {
            using (Process sut = ReturnProcess(string.Empty))
            {
                sut.Start();

                string messageFromApp = sut.StandardOutput.ReadLine();

                do
                {
                    Thread.Sleep(50);
                } while (!sut.HasExited);

                Assert.That(messageFromApp, Is.EqualTo(string.Empty));
                Assert.That(sut.ExitCode, Is.Zero);
            }
        }


        private static Process ReturnProcess(string input)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = input,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = Path.Combine(CurrentDirectory, "App.exe"),
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };

            return process;
        }

        [Test]
        public void Given_Valid_Input_Flag_Should_Pass()
        {
            TextEncoder textEncoder = new TextEncoder();
            using (Process sut = ReturnProcess("-b"))
            {
                sut.Start();

                string messageFromApp = sut.StandardOutput.ReadLine();

                do
                {
                    Thread.Sleep(50);
                } while (!sut.HasExited);

                Assert.That(messageFromApp, Is.EqualTo(string.Empty));
                Assert.That(sut.ExitCode, Is.Zero);
            }
        }

        [Test]
        public void Given_Valid_Input_Flag_And_Message_Should_Pass()
        {
            TextEncoder textEncoder = new TextEncoder();

            Assert.That("...|---|...", Is.EqualTo(textEncoder.GetMorseCode("-m SOS -b")));
        }
    }
}

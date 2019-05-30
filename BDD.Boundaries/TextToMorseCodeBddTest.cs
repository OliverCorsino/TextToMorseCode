using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace BDD.Boundaries
{
    public class TextToMorseCodeBddTest
    {
        [TestFixture]
        public class AppBTests
        {
            private static readonly string CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            [TestCase("E", ".")]
            [TestCase("SOS", "...|---|...")]
            [TestCase("HOLA", "....|---|.-..|.-")]
            [TestCase("HoLa", "....|---|.-..|.-")]
            public void Given_Valid_Input_Should_Pass(string input, string output)
            {
                using (Process sut = ReturnProcess(input))
                {
                    sut.Start();

                    string messageFromApp = sut.StandardOutput.ReadLine();

                    do
                    {
                        Thread.Sleep(50);
                    } while (!sut.HasExited);

                    Assert.That(messageFromApp, Is.EqualTo(output));
                    Assert.That(sut.ExitCode, Is.Zero);
                }
            }

            private static Process ReturnProcess(string input)
            {
                Process process = new Process()
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
                using (Process sut = ReturnProcess("-m SOS -b"))
                {
                    sut.Start();

                    string messageFromApp = sut.StandardOutput.ReadLine();

                    do
                    {
                        Thread.Sleep(50);
                    } while (!sut.HasExited);

                    Assert.That(messageFromApp, Is.EqualTo("...|---|..."));
                    Assert.That(sut.ExitCode, Is.Zero);
                }
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestsRelevantToMvc5OnMono
{
    [TestFixture]
    public class Log
    {
        [Test]
        public void DisplayCLRVersion()
        {
            Console.WriteLine(Environment.Version);
        }
    }
}

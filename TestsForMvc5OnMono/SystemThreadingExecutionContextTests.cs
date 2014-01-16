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
    public class SystemThreadingExecutionContextTests
    {
        const string setBeforeCapture = "set before capture";
        const string setAfterCapture = "set after capture";
        const string datakey1 = "datakey1";
        const string datakey2 = "datakey2";

        ExecutionContext executionContext;
        static string lastSpiedValue1;
        static string lastSpiedValue2;

        [Test]
        public void LogicalCallContext_should_carry_thread_context_across_ExecutionContext_Capture()
        {
            //A
            var lcc = GetCurrentLogicalCallContext();
            lcc.SetData(datakey1, setBeforeCapture);
            executionContext = ExecutionContext.Capture();
            lcc.SetData(datakey1, setAfterCapture);
            lcc.SetData(datakey2, setAfterCapture);
            DebugSpyOnCurrentThread();
            Debug.Assert(lcc.GetData(datakey1) as string == setAfterCapture);

            //A
            var otherThread= new Thread(SwitchExecutionContextThenSpyOnThread){Name = "New Thread"};
            otherThread.Start();

            //A
            Assert.AreNotEqual(setAfterCapture, lastSpiedValue1);
            Assert.AreEqual(setBeforeCapture, lastSpiedValue1);
            Assert.IsNull(lastSpiedValue2);
        }

        static LogicalCallContext GetCurrentLogicalCallContext()
        {
            var lcc = typeof (ExecutionContext)
                              .GetProperty("LogicalCallContext", BindingFlags.NonPublic | BindingFlags.Instance)
                              .GetValue(Thread.CurrentThread.ExecutionContext) as LogicalCallContext;
            return lcc;
        }

        static void CalledBack(object previous)
        {
            lastSpiedValue1 = GetCurrentLogicalCallContext().GetData(datakey1) as string;
            lastSpiedValue2 = GetCurrentLogicalCallContext().GetData(datakey2) as string;
        } 

        void SwitchExecutionContextThenSpyOnThread(object state)
        {
            ExecutionContext.Run(executionContext, CalledBack, lastSpiedValue1);
        }

        static void DebugSpyOnCurrentThread()
        {
            var si = new SerializationInfo(typeof(ExecutionContext), new FormatterConverter());
            var sc = new StreamingContext();
            Thread.CurrentThread.ExecutionContext.GetObjectData(si, sc);
            var originallcc = si.GetValue("LogicalCallContext", typeof(LogicalCallContext));
            var lcc = originallcc as LogicalCallContext;

            Console.WriteLine("On thread: {0},{1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(datakey1 + ":" + lcc.GetData(datakey1));
            Console.WriteLine("datakey2" + ":" + lcc.GetData("datakey2"));
        }
    }
}

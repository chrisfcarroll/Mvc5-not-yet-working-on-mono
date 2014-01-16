using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace TestsRelevantToMvc5OnMono
{
    public class MultiThreadingTestSkeleton
    {
        string usingResource = null;  //0 for false, 1 for true.
        ExecutionContext executionContext;
        List<string> threadsThatTriedToEnterMethod = new List<string>();
        List<string> threadsThatGotTheResource = new List<string>();
        List<string> threadsDenied = new List<string>();
        List<string> threadsWhichWereGivenADirtyResource = new List<string>();
        [Test]
        public void UnderstandInterlockCompareExchange()
        {
            for (int i = 0; i < 10; i++)
            {
                var myThread = new Thread(new ThreadStart(RepeatedlyUseResouce))
                    {
                            Name = String.Format("Thread{0}", i + 1)
                    };
                Thread.Sleep(i);
                myThread.Start();
            }
            Assert.Greater(threadsThatGotTheResource.Count, 1, "Expected more than 1 thread to have had access to the resource");
            if (!threadsDenied.Any())
            {
                Assert.Inconclusive("Didn't get any collisions so don't know if thread safety worked");
            }
            Assert.IsEmpty(threadsWhichWereGivenADirtyResource);
        }

        void RepeatedlyUseResouce()
        {
            for (int i = 0; i < 5; i++)
            {
                UseResource();
                Thread.Sleep(2);
            }
        }

        bool TrueAfter20MilliSleep
        {
            get
            {
                Thread.Sleep(20);
                return true;
            }
        }

        //A simple method that denies reentrancy. 
        bool UseResource(string nameInContext = null)
        {
            var me = nameInContext ?? Thread.CurrentThread.Name;
            threadsThatTriedToEnterMethod.Add(me);
            if (null == Interlocked.CompareExchange(ref usingResource, me, null))
                    //if (usingResource == null && TrueAfter20MilliSleep && (usingResource = me) == me)
            {
                Console.WriteLine("{0} acquired the lock", Thread.CurrentThread.Name);
                threadsThatGotTheResource.Add(me);
                Thread.Sleep(10); //long enough for other threads to try to get the resource;
                if (usingResource != me) { threadsWhichWereGivenADirtyResource.Add(me); }
                Console.WriteLine("{0} exiting lock", Thread.CurrentThread.Name);
                Interlocked.Exchange(ref usingResource, null);
                return true;
            }
            else
            {
                Console.WriteLine("   {0} was denied the lock", Thread.CurrentThread.Name);
                threadsDenied.Add(me);
                return false;
            }
        }
        
    }
}
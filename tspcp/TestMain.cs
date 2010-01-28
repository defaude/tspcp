using System;
using System.Threading;

namespace tspcp
{
    /// <summary>
    /// Simple test class that uses the classes in Dummies.cs to test the behaviour of the AbstractQueueConsumer, AbstractQueueProducer and SynchronizedQueue classes.
    /// </summary>
    class TestMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

            // This using block defines the lifetime of the queue and therefore the lifetime of all producers and consumers
            using (SynchronizedQueue<string> qs = new SynchronizedQueue<string>(true))
            {
                // Now we're creating several producers and consumers
                AbstractQueueProducer<string> producer1 = new DummyProducer(qs);
                AbstractQueueProducer<string> producer2 = new DummyProducer(qs);
                AbstractQueueProducer<string> producer3 = new DummyProducer(qs);
                AbstractQueueProducer<string> producer4 = new DummyProducer(qs);
                AbstractQueueConsumer<string> consumer1 = new DummyConsumer(qs);
                AbstractQueueConsumer<string> consumer2 = new DummyConsumer(qs);
                AbstractQueueConsumer<string> consumer3 = new DummyConsumer(qs);
                AbstractQueueConsumer<string> consumer4 = new DummyConsumer(qs);
                AbstractQueueConsumer<string> consumer5 = new DummyConsumer(qs);

                // All consumers/producers have been created. Now let's have the main thread rest for a while.
                Thread.Sleep(5000);

                // Alright, enough sleeping for the main thread! Let's get out of this using block and therefore kill all consumers/workers and the queue itself!
            }

            Console.WriteLine("Goodbye, world! (press enter)");
            Console.Read();
        }
    }
}

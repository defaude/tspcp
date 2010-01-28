using System;
using System.Threading;

namespace tspcp
{
    /// <summary>
    /// This class implements the queue producer for string tasks.
    /// 
    /// We only need to pass down the queue object to the base class's constructor and override the produce method!
    /// </summary>
    class DummyProducer : AbstractQueueProducer<string>
    {
        public DummyProducer(SynchronizedQueue<string> queue) : base(queue) { }

        protected override string produce()
        {
            Thread.Sleep(200);
            return "tasky";
        }
    }

    /// <summary>
    /// This class implements the queue consumer for string tasks.
    /// 
    /// We only need to pass down the queue object to the base class's constructor and override the consume method!
    /// </summary>
    class DummyConsumer : AbstractQueueConsumer<string>
    {
        public DummyConsumer(SynchronizedQueue<string> queue) : base(queue) { }

        protected override void consume(string task)
        {
            Console.WriteLine(task);
            Thread.Sleep(500);
        }
    }
}

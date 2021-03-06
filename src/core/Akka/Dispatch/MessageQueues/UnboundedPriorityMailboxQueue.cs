﻿using System;
using Akka.Actor;
using Akka.Util;

namespace Akka.Dispatch.MessageQueues
{
    /// <summary> 
    /// Base class message queue that uses a priority generator for messages 
    /// </summary>
    public class UnboundedPriorityMessageQueue : BlockingMessageQueue
    {
        private readonly ListPriorityQueue _prioQueue = new ListPriorityQueue();

        public UnboundedPriorityMessageQueue(Func<object, int> priorityGenerator)
        {
            _prioQueue.SetPriorityCalculator(priorityGenerator);
        }

        protected override int LockedCount
        {
            get { return _prioQueue.Count(); }
        }

        protected override void LockedEnqueue(Envelope envelope)
        {
            _prioQueue.Enqueue(envelope);
        }

        protected override bool LockedTryDequeue(out Envelope envelope)
        {
            if (_prioQueue.Count() > 0)
            {
                envelope = _prioQueue.Dequeue();
                return true;
            }
            envelope = default (Envelope);
            return false;
        }
    }
}
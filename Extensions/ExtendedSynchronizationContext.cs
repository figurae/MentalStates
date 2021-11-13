using System;
using System.Threading;

namespace MentalStates.Extensions
{
    public class ExtendedSynchronizationContext : SynchronizationContext
    {
        private readonly Action _completed;

        public ExtendedSynchronizationContext(Action completed)
        {
            _completed = completed;
        }

        public override SynchronizationContext CreateCopy()
        {
            return new ExtendedSynchronizationContext(_completed);
        }

        public override void OperationCompleted()
        {
            _completed();
        }

    }
}
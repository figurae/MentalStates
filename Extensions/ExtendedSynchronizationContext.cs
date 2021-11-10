using System;
using System.Threading;

namespace MentalStates.Extensions
{
    public class ExtendedSynchronizationContext : SynchronizationContext
    {
        private readonly Action completed;

        public ExtendedSynchronizationContext(Action completed)
        {
            this.completed = completed;
        }

        public override SynchronizationContext CreateCopy()
        {
            return new ExtendedSynchronizationContext(this.completed);
        }

        public override void OperationCompleted()
        {
            this.completed();
        }

    }
}
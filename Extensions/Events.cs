using System;
using System.Threading;
using System.Threading.Tasks;
using MentalStates.Models;

namespace MentalStates.Extensions
{
    public static class EventInvokeAsync
    {
        public static Task InvokeAsync<T>(this EventHandler<T> @this, object sender, T eventArgs)
        {
            if (@this == null)
            {
                return Task.CompletedTask;
            }

            var tcs = new TaskCompletionSource<bool>();
            var sc = new ExtendedSynchronizationContext(() => tcs.SetResult(true));

            SynchronizationContext.SetSynchronizationContext(sc);

            @this.Invoke(sender, eventArgs);

            return tcs.Task;
        }
    }

    public class ItemAddedEventArgs<T> : EventArgs
    {
        public ItemAddedEventArgs(Item item)
        {
            m_item = item;
        }

        private Item m_item;

        public Item Item
        {
            get { return m_item; }
        }
    }

    public class SliderEventCallbackArgs
    {
        public SliderEventCallbackArgs(int itemId, float value)
        {
            m_itemId = itemId;
            m_value = value;
        }

        private int m_itemId;
        private float m_value;

        public int ItemId { get { return m_itemId; } }
        public float Value { get { return m_value; } }
    }

    public class UpdateEventCallbackArgs
    {
        public UpdateEventCallbackArgs(int itemId, string title)
        {
            m_itemId = itemId;
            m_title = title;
        }

        private int m_itemId;
        private string m_title;

        public int ItemId { get { return m_itemId; } }
        public string Title { get { return m_title; } }
    }
}
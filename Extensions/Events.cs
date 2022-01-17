using System;
using System.Threading;
using System.Threading.Tasks;
using MentalStates.Models;

namespace MentalStates.Extensions
{
    public static class EventInvokeAsync
    {
        public static Task InvokeAsync<T>(this EventHandler<T> eventHandler, object sender, T eventArgs)
        {
            if (eventHandler == null)
            {
                return Task.CompletedTask;
            }

            var tcs = new TaskCompletionSource<bool>();
            var sc = new ExtendedSynchronizationContext(() => tcs.SetResult(true));

            SynchronizationContext.SetSynchronizationContext(sc);

            eventHandler.Invoke(sender, eventArgs);

            return tcs.Task;
        }
    }

    public class ItemUpdatedEventArgs<T> : EventArgs
    {
        public ItemUpdatedEventArgs(Item item)
        {
            _item = item;
        }

        private Item _item;

        public Item Item
        {
            get { return _item; }
        }
    }

    public class SliderEventCallbackArgs
    {
        public SliderEventCallbackArgs(int itemId, float value)
        {
            _itemId = itemId;
            _value = value;
        }

        private int _itemId;
        private float _value;

        public int ItemId { get { return _itemId; } }
        public float Value { get { return _value; } }
    }

    public class UpdateEventCallbackArgs
    {
        public UpdateEventCallbackArgs(int itemId, string title)
        {
            _itemId = itemId;
            _title = title;
        }

        private int _itemId;
        private string _title;

        public int ItemId { get { return _itemId; } }
        public string Title { get { return _title; } }
    }
}
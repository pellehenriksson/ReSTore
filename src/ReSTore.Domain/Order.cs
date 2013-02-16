using System;
using ReSTore.Infrastructure;
using ReSTore.Messages.Events;

namespace ReSTore.Domain
{
    public class Order : Aggregate
    {
        private Guid _orderId;

        public Order()
        {
            
        }

        public Order(Guid orderId)
        {
            Publish(new OrderCreated() { OrderId = orderId });
        }

        public void AddItem(Guid itemId)
        {
            Publish(new ItemAddedToOrder() { OrderId = _orderId, ItemId = itemId });
        }

        private void Apply(OrderCreated evt)
        {
            _orderId = evt.OrderId;
        }
    }
}
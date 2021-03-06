using System;
using ReSTore.Infrastructure;
using ReSTore.Messages.Commands;

namespace ReSTore.Domain.CommandHandlers
{
    public class CreateOrderHandler : ICommandHandler<CreateOrder>
    {
        private readonly IRepository<Guid> _repository;

        public CreateOrderHandler(IRepository<Guid> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateOrder command)
        {
            var order = _repository.GetAggregate<Order>(command.OrderId);
            if (order != null)
                throw new Exception("Order already created");

            order = new Order(command.OrderId);
            _repository.Store(command.OrderId, order, command.ApplyCommandHeaders());
        }
    }
}
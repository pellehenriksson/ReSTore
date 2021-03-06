using System;
using System.Collections.Generic;

namespace ReSTore.Infrastructure
{
    public interface IRepository<TId>
    {
        T GetAggregate<T>(TId id) where T : Aggregate, new();
        void Store(TId id, Aggregate aggregate, Action<IDictionary<string,object>> applyHeaders);
        IEnumerable<object> GetEvents(TId id);
    }

}

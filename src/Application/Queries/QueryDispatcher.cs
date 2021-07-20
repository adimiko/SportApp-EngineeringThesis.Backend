using System;
using System.Threading.Tasks;
using Application.DTOs;
using Autofac;

namespace Application.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;
        public QueryDispatcher(IComponentContext context)
            => _context = context;

        public async Task<TResult> DispatchAsync<TResult, TQuery>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            if(query == null) throw new ArgumentNullException(nameof(query),
            $"Query {typeof(TQuery).Name} cannot be null.");

            var handler = _context.Resolve<IQueryHandler<TQuery, TResult>>();
            return await handler.HandleAsync(query);
        }
    }
}
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TResult, TQuery>(TQuery query)where TQuery : IQuery<TResult>;
    }
}
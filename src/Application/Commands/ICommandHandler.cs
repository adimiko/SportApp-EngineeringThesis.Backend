using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
        Task HandleAsync(T command);
    }
}
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}
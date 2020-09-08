using System.Threading.Tasks;

namespace IExpress.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();

    }
}

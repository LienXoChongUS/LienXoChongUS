using LXxUS.Models;
using LXxUS.DataAccess.Repository.IRepository;

namespace LXxUS.DataAccess.Repository.IRepository
{
    public interface IRequestRepository : IRepository<Request>
    {
        void Update(Request request);
    }
}
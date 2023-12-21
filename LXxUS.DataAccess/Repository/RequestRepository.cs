using LXxUS.Models;
using LXxUS.DataAccess.Repository;
using LXxUS.DataAccess.Data;
using LXxUS.DataAccess.Repository.IRepository;

namespace LXxUS.DataAccess.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        private readonly AppDbContext _dbContext;
        public RequestRepository(AppDbContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public void Update(Request request)
        {
            _dbContext.Update(request);
        }
    }
}
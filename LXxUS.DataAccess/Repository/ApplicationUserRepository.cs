using LXxUS.DataAccess.Data;
using LXxUS.DataAccess.Repository.IRepository;
using LXxUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LXxUS.DataAccess.Repository
{

/*ApplicationUserRepository là một class kế thừa từ Repository<ApplicationUser> và thực hiện interface IApplicationUserRepository. 
  Thừa hưởng các phương thức chung từ Repository và triển khai các phương thức từ IApplicationUserRepository.
*/
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository IApplicationUserRepository.
    {

        /*onstructor của ApplicationUserRepository nhận một tham số kiểu AppDbContext
          Nó gọi constructor của lớp cơ sở Repository<ApplicationUser> và gán giá trị db vào biến _db.
        */ 
        private AppDbContext _db;
        public ApplicationUserRepository(AppDbContext db) : base(db) { 
            _db = db;   
        }
    }
}

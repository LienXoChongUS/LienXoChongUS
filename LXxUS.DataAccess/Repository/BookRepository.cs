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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private AppDbContext _db;
        public BookRepository(AppDbContext db) : base(db) { 
            _db = db;   
        }

        public void Update(Book obj)
        {
            _db.Books.Update(obj);
        }
    }
}

using LXxUS.DataAccess.Data;
using LXxUS.DataAccess.Repository.IRepository;
using LXxUS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXxUS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IBookRepository Book { get; private set; }
        public IRequestRepository RequestRepository { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Book = new BookRepository(_db);
            RequestRepository = new RequestRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentApp.Models.ViewModel;
using RentApp.Repository.Entities;
using RentApp.Repository.Interface;

namespace RentApp.Repository.Implementation
{
    public class UserRepository:IUserRepository
    {

        public readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id == id);
        }
        public async Task<User> CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteById(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return false;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

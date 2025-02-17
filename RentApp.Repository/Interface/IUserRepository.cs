using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Models.ViewModel;
using RentApp.Repository.Entities;

namespace RentApp.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        User GetById(Guid id);
        Task<User> CreateUser(User user);
        Task<bool> DeleteById(Guid id);

    }
}

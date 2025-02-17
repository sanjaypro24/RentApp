using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Models.ViewModel;

namespace RentApp.Services.Interface
{
    public interface IUserServices
    {
        Task<List<UserModel>> GetAll();
        UserModel GetById(Guid id);
        Task<UserModel> CreateUser(UserModel userModel);
        Task<bool> DeleteById(Guid id);

    }
}

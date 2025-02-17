using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentApp.Models.ViewModel;
using RentApp.Repository.Entities;
using RentApp.Repository.Interface;
using RentApp.Services.Interface;

namespace RentApp.Services.Implementation
{
    public class UserServices:IUserServices
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            
        }

        public async Task<List<UserModel>> GetAll()
        {
            List<User> users = await _userRepo.GetAll();
            List<UserModel> userModels = _mapper.Map<List<UserModel>>(users);
            return userModels;
        }

        public UserModel GetById(Guid id)
        {
            User user = _userRepo.GetById(id);
            UserModel userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }
        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            User userEntity = _mapper.Map<User>(userModel);
            
            userEntity.Id = Guid.NewGuid();
            User createdUser = await _userRepo.CreateUser(userEntity);
            return _mapper.Map<UserModel>(createdUser);
        }
        public async Task<bool> DeleteById(Guid id)
        {
            return await _userRepo.DeleteById(id);
        }
    }
}

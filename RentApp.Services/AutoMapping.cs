using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentApp.Models.ViewModel;
using RentApp.Repository.Entities;

namespace RentApp.Services
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Ridecar, RidecarModel>().ReverseMap();
        }
    }
}

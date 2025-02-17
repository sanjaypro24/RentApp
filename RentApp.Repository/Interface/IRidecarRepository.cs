using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Repository.Entities;

namespace RentApp.Repository.Interface
{
    public interface IRidecarRepository
    {
        Task<List<Ridecar>> GetAll();
        Ridecar GetById(Guid id);
        Task<Ridecar> CreateRidecar(Ridecar ridecar);
        Task<bool> DeleteById(Guid id);
    }
}

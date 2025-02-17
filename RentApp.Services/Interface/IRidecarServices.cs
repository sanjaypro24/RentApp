using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Models.ViewModel;

namespace RentApp.Services.Interface
{
     public interface IRidecarServices
    {
        Task<List<RidecarModel>> GetAll();
        RidecarModel GetById(Guid id);
        Task<RidecarModel> CreateRidecar(RidecarModel ridecarModel);

        Task<bool> DeleteById(Guid id);
    }
}

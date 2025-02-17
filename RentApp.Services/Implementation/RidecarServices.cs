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
    public class RidecarServices:IRidecarServices
    {
        private readonly IRidecarRepository _ridecarRepo;
        private readonly IMapper _mapper;
        public RidecarServices(IRidecarRepository ridecarRepo, IMapper mapper)
        {
            _ridecarRepo = ridecarRepo;
            _mapper = mapper;
        }

        public async Task<List<RidecarModel>> GetAll()
        {
            List<Ridecar> ridecars = await _ridecarRepo.GetAll();
            List<RidecarModel> rideModels = _mapper.Map<List<RidecarModel>>(ridecars);
            return rideModels;
        }

        public RidecarModel GetById(Guid id)
        {
            Ridecar ridecar = _ridecarRepo.GetById(id);
            RidecarModel ridecarModel = _mapper.Map<RidecarModel>(ridecar);
            return ridecarModel;
        }
        public async Task<RidecarModel> CreateRidecar(RidecarModel ridecarModel)
        {
            Ridecar ridecarEntity = _mapper.Map<Ridecar>(ridecarModel);
            ridecarEntity.Carid = Guid.NewGuid();
            Ridecar createdRidecar = await _ridecarRepo.CreateRidecar(ridecarEntity);
            return _mapper.Map<RidecarModel>(createdRidecar);
        }
        public async Task<bool> DeleteById(Guid id)
        {
            return await _ridecarRepo.DeleteById(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentApp.Repository.Entities;
using RentApp.Repository.Interface;

namespace RentApp.Repository.Implementation
{
    public class RidecarRepository : IRidecarRepository
    {
        public readonly AppDbContext _dbContext;

        public RidecarRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<List<Ridecar>> GetAll()
        {
            return await _dbContext.Ridecars.ToListAsync();
        }

        public Ridecar GetById(Guid id)
        {
            return _dbContext.Ridecars.FirstOrDefault(user => user.Carid == id);
        }
        public async Task<Ridecar> CreateRidecar(Ridecar ridecar)
        {
            await _dbContext.Ridecars.AddAsync(ridecar);
            await _dbContext.SaveChangesAsync();
            return ridecar;
        }
        public async Task<bool> DeleteById(Guid id)
        {
            var ridecar = await _dbContext.Ridecars.FindAsync(id);
            if (ridecar == null)
                return false;

            _dbContext.Ridecars.Remove(ridecar);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

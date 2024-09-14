using Microsoft.EntityFrameworkCore;
using STMData.Exceptions;
using STMData.Repositories.Interfaces;
using STMDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMData.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly STMDbContext _context;

        public AddressRepository(STMDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Address entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.Addresses.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);

            if (address == null)
            {
                throw new DbDataNotFoundException($"No data found for the id: {id}");
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            if(! await _context.Addresses.AsNoTracking().AnyAsync())
            {
                throw new DbDataNotFoundException($"No data found.");
            }
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetByIdAsync(long id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(p => p.Id == id);

            if (address == null)
            {
                throw new DbDataNotFoundException($"No data found for the id : {id}");
            }

            return address;
        }

        public async Task UpdateAsync(Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = "Process";

            _context.Addresses.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

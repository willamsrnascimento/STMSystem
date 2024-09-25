using Microsoft.EntityFrameworkCore;
using STMData.Exceptions;
using STMData.Repositories.Interfaces;
using STMDomain.Domain;

namespace STMData.Repositories
{
    public class FamilyDataRepository : IFamilyDataRepository
    {
        private readonly STMDbContext _context;

        public FamilyDataRepository(STMDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(FamilyData entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.FamilyDatas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var familyData = await _context.FamilyDatas.FirstOrDefaultAsync(x => x.Id == id);

            if (familyData == null)
            {
                throw new DbDataNotFoundException($"No data found for the id: {id}");
            }

            _context.FamilyDatas.Remove(familyData);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FamilyData>> GetAllAsync()
        {
            if (!await _context.FamilyDatas.AsNoTracking().AnyAsync())
            {
                throw new DbDataNotFoundException($"No data found.");
            }
            return await _context.FamilyDatas.ToListAsync();
        }

        public async Task<FamilyData> GetByIdAsync(long id)
        {
            var familyData = await _context.FamilyDatas.FirstOrDefaultAsync(p => p.Id == id);

            if (familyData == null)
            {
                throw new DbDataNotFoundException($"No data found for the id : {id}");
            }

            return familyData;
        }

        public async Task UpdateAsync(FamilyData entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = "Process";

            _context.FamilyDatas.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

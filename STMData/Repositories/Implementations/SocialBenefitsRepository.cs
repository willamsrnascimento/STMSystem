using Microsoft.EntityFrameworkCore;
using STMData.Exceptions;
using STMData.Repositories.Interfaces;
using STMDomain.Domain;

namespace STMData.Repositories.Implementations
{
    public class SocialBenefitsRepository : ISocialBenefitsRepository
    {
        private readonly STMDbContext _context;

        public SocialBenefitsRepository(STMDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(SocialBenefits entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SocialBenefits>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SocialBenefits> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<SocialBenefits>> GetSocialBenefitsByIdListAsync(ICollection<SocialBenefits> socialBenefits)
        {
            if(!await _context.SocialBenefits.AsNoTracking().AnyAsync())
            {
                throw new DbDataNotFoundException("No data found in SocialBenefits table");
            }

            List<long> ids = socialBenefits.Select(s => s.Id).ToList();
            var socialBenefitsSelected = await _context.SocialBenefits.Where(s => ids.Contains(s.Id)).ToListAsync();

            return socialBenefitsSelected;
        }

        public Task UpdateAsync(SocialBenefits entity)
        {
            throw new NotImplementedException();
        }
    }
}

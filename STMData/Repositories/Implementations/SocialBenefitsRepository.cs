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

        public async Task CreateAsync(SocialBenefits entity)
        {

            try
            {
                await _context.SocialBenefits.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw new DbCreateException($"Erro while creating a new entity name of {nameof(SocialBenefits)}");
            }
        }

        public async Task DeleteAsync(long id)
        {
            var socialBenefit = _context.SocialBenefits.AsNoTracking().FirstOrDefault(s => s.Id == id);

            if (socialBenefit == null)
            {
                throw new DbDataNotFoundException($"Data not found which id is {id}");
            }

            try
            {
                _context.SocialBenefits.Remove(socialBenefit);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw new DbDeleteException($"An error occured while executing delete on method {nameof(DeleteAsync)}" +
                                            $"in {nameof(SocialBenefitsRepository)}") ;
            }
        }

        public async Task<IEnumerable<SocialBenefits>> GetAllAsync()
        {
            if (!await _context.SocialBenefits.AsNoTracking().AnyAsync())
            {
                throw new DbDataNotFoundException($"No data found in {nameof(SocialBenefits)} table.");
            }

            return await _context.SocialBenefits.ToListAsync();
        }

        public async Task<SocialBenefits> GetByIdAsync(long id)
        {
            if(! await _context.SocialBenefits.AsNoTracking().AnyAsync())
            {
                throw new DbDataNotFoundException($"No data found in {nameof(SocialBenefits)} table.");
            }

            var socialBenefits = await _context.SocialBenefits.FirstOrDefaultAsync(s => s.Id == id);

            if (socialBenefits == null)
            {
                throw new DbDataNotFoundException($"No data found in {nameof(SocialBenefits)} table and id {id}.");
            }

            return socialBenefits;
        }

        public async Task<ICollection<SocialBenefits>> GetSocialBenefitsByIdListAsync(ICollection<SocialBenefits> socialBenefits)
        {
            if(!await _context.SocialBenefits.AsNoTracking().AnyAsync())
            {
                throw new DbDataNotFoundException($"No data found in {nameof(SocialBenefits)} table.");
            }

            List<long> ids = socialBenefits.Select(s => s.Id).ToList();
            var socialBenefitsSelected = await _context.SocialBenefits.Where(s => ids.Contains(s.Id)).ToListAsync();

            return socialBenefitsSelected;
        }

        public async Task UpdateAsync(SocialBenefits entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Erro while executing the method {nameof(UpdateAsync)}. " +
                                                $"The named object {nameof(entity)} cannot be null.");
            }

            try
            {
                _context.SocialBenefits.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new DbDeleteException($"An error occured while executing update on method {nameof(UpdateAsync)}" +
                                            $"in {nameof(SocialBenefitsRepository)}");
            }
        }
    }
}

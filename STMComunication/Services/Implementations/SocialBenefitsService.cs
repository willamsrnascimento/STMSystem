using STMComunication.Errors.Exceptions;
using STMComunication.Services.Interfaces;
using STMData.Repositories.Interfaces;
using STMDomain.Domain;

namespace STMComunication.Services.Implementations
{
    public class SocialBenefitsService : ISocialBenefitsService
    {
        private readonly ISocialBenefitsRepository _socialBenefitsRepository;

        public SocialBenefitsService(ISocialBenefitsRepository socialBenefitsRepository)
        {
            _socialBenefitsRepository = socialBenefitsRepository;
        }

        public async Task<SocialBenefits> CreateAsync(SocialBenefits entity)
        {
            try
            {
                await _socialBenefitsRepository.CreateAsync(entity);
                return entity;
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }

        public async Task<IEnumerable<SocialBenefits>> GetAllAsync()
        {
            try
            {
                return await _socialBenefitsRepository.GetAllAsync();
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }

        public async Task<SocialBenefits> GetByIdAsync(long id)
        {
            try
            {
                var socialBenefits = await _socialBenefitsRepository.GetByIdAsync(id);
                return socialBenefits;
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }

        public async Task<SocialBenefits> UpdateAsync(SocialBenefits entity)
        {
            try
            {
                await _socialBenefitsRepository.UpdateAsync(entity);
                return entity;
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }
        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                await _socialBenefitsRepository.DeleteAsync(id);
                return true;
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }
    }
}

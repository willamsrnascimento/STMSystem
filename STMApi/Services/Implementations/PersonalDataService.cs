using STMApi.Exceptions;
using STMApi.Services.Interfaces;
using STMData.Repositories.Interfaces;
using STMDomain.Domain;

namespace STMApi.Services.Implementations
{
    public class PersonalDataService : IPersonalDataService
    {
        private IPersonalDataRepository _personalDataRepository;

        public PersonalDataService(IPersonalDataRepository personalDataRepository)
        {
            _personalDataRepository = personalDataRepository;
        }

        public async Task CreateAsync(PersonalData entity)
        {
            try
            {
                await _personalDataRepository.CreateAsync(entity);
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                await _personalDataRepository.DeleteAsync(id);
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }

        public async Task<IEnumerable<PersonalData>> GetAllAsync()
        {
            try
            {
                return await _personalDataRepository.GetAllAsync();
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }

        public async Task<PersonalData> GetByIdAsync(long id)
        {
            try
            {
                return await _personalDataRepository.GetByIdAsync(id);
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }

        public async Task UpdateAsync(PersonalData entity)
        {
            try
            {
                await _personalDataRepository.UpdateAsync(entity);
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }
    }
}

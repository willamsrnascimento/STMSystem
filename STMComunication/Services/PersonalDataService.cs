using STMComunication.Errors.Exceptions;
using STMComunication.Services.Interfaces;
using STMData.Repositories.Interfaces;
using STMDomain.Domain;

namespace STMComunication.Services
{
    public class PersonalDataService : IPersonalDataService
    {
        private readonly IPersonalDataRepository _personalDataRepository;

        public PersonalDataService(IPersonalDataRepository personalDataRepository)
        {
            _personalDataRepository = personalDataRepository;
        }

        public async Task<PersonalData> CreateAsync(PersonalData entity)
        {
            try
            {
                await _personalDataRepository.CreateAsync(entity);
                return entity;
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
                var personalData = await _personalDataRepository.GetByIdAsync(id);
                return personalData;
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }

        public async Task<PersonalData> UpdateAsync(PersonalData entity)
        {
            try
            {
                await _personalDataRepository.UpdateAsync(entity);
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
                await _personalDataRepository.DeleteAsync(id);
                return true;
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
        }
    }
}

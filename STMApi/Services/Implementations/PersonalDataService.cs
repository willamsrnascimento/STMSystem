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
            await _personalDataRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _personalDataRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PersonalData>> GetAllAsync()
        {
            return await _personalDataRepository.GetAllAsync();
        }

        public async Task<PersonalData> GetByIdAsync(int id)
        {
            return await _personalDataRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(PersonalData entity)
        {
            await _personalDataRepository.UpdateAsync(entity);
        }
    }
}

using AutoMapper;
using STMComunication.Dtos;
using STMComunication.Errors.Exceptions;
using STMComunication.Services.Interfaces;
using STMData.Repositories.Interfaces;
using STMDomain.Domain;

namespace STMComunication.Services.Implementations
{
    public class PersonalDataService : IPersonalDataService
    {
        private readonly IPersonalDataRepository _personalDataRepository;
        private readonly IMapper _mapper;

        public PersonalDataService(IPersonalDataRepository personalDataRepository, IMapper mapper)
        {
            _personalDataRepository = personalDataRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync2(PersonalDataRequestDto entity)
        {
            try
            {

                var personalData = _mapper.Map<PersonalData>(entity);
                await _personalDataRepository.CreateAsync(personalData);
            }
            catch (DbConcurrencyException)
            {
                throw new DbConcurrencyException("Error on conecting to database.");
            }
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
                var personalData = await _personalDataRepository.GetByIdAsync(id);
                return personalData;
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

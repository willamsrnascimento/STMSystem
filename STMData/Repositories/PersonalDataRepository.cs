using Microsoft.EntityFrameworkCore;
using STMData.Exceptions;
using STMData.Repositories.Interfaces;
using STMDomain.Domain;

namespace STMData.Repositories
{
    public class PersonalDataRepository : IPersonalDataRepository
    {
        private readonly STMDbContext _context;
        private readonly ISocialBenefitsRepository _socialBenefitsRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IFamilyDataRepository _familyDataRepository;
        public PersonalDataRepository(STMDbContext context,
                                      ISocialBenefitsRepository socialBenefitsRepository,
                                      IAddressRepository addressRepository,
                                      IFamilyDataRepository familyDataRepository)
        {
            _context = context;
            _socialBenefitsRepository = socialBenefitsRepository;
            _addressRepository = addressRepository;
            _familyDataRepository = familyDataRepository;
        }

        public async Task CreateAsync(PersonalData entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.SocialBenefits = await _socialBenefitsRepository.GetSocialBenefitsByIdListAsync(entity.SocialBenefits);

            await _context.PersonalDatas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var personalData = await _context.PersonalDatas
                                             .Include(p => p.Contacts)
                                             .Include(p => p.SocialBenefits)
                                             .FirstOrDefaultAsync(x => x.Id == id);

            if (personalData == null)
            {
                throw new DbDataNotFoundException($"No data found for the id: {id}");
            }

            _context.PersonalDatas.Remove(personalData);
            await _context.SaveChangesAsync();

            try
            {
                await _addressRepository.DeleteAsync(personalData.AddressId);

                if (personalData.FamilyDataId != null || personalData.FamilyDataId != 0)
                {
                    await _familyDataRepository.DeleteAsync(personalData.FamilyDataId.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<IEnumerable<PersonalData>> GetAllAsync()
        {
            if (!await _context.PersonalDatas.AsNoTracking().AnyAsync())
            {
                throw new DbDataNotFoundException("No data found.");
            }

            return await _context.PersonalDatas.ToListAsync();
        }

        public async Task<PersonalData> GetByCPF(string cpf)
        {
            var personalData = await _context.PersonalDatas.FirstOrDefaultAsync(p => p.CPF == cpf);

            if (personalData == null)
            {
                throw new DbDataNotFoundException($"No data found for the cpf: {cpf}");
            }

            return personalData;
        }

        public async Task<PersonalData> GetByIdAsync(long id)
        {
            var personalData = await _context.PersonalDatas
                                .Include(p => p.Education)
                                .Include(p => p.Gender)
                                .Include(p => p.Address)
                                .Include(p => p.Contacts)
                                .Include(p => p.FamilyData)
                                .Include(p => p.MaritalStatus)
                                .Include(p => p.SocialBenefits)
                                .Include(p => p.Status)
                                .Include(p => p.SexualOrientation)
                                .FirstOrDefaultAsync(p => p.Id == id);

            if (personalData == null)
            {
                throw new DbDataNotFoundException($"No data found for the id : {id}");
            }

            return personalData;
        }

        public async Task UpdateAsync(PersonalData entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Erro while executing the method {nameof(UpdateAsync)}. " +
                                                $"The named object {nameof(entity)} cannot be null.");
            }

            _context.PersonalDatas.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

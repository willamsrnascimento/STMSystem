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
    public class PersonalDataRepository : IPersonalDataRepository
    {
        private readonly STMDbContext _context;
        public PersonalDataRepository(STMDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PersonalData entity)
        {
            entity.CreatedBy = "Process";
            await _context.PersonalDatas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var personalData = await _context.PersonalDatas.FirstOrDefaultAsync(x => x.Id == id);

            if(personalData == null)
            {
                throw new DbDataNotFoundException($"No data found for the id: {id}");
            }

            _context.PersonalDatas.Remove(personalData);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonalData>> GetAllAsync()
        {
            if (! await _context.PersonalDatas.AnyAsync())
            {
                throw new DbDataNotFoundException("No data found.");
            }

            return await _context.PersonalDatas
                                .Include(p => p.Education)
                                .Include(p => p.GenderIdentity)
                                .Include(p => p.Address)
                                .Include(p => p.Contacts)
                                .Include(p => p.FamilyData)
                                .Include(p => p.MaritalStatus)
                                .Include(p => p.SocialPrograms)
                                .Include(p => p.Status)
                                .Include(p => p.SexualOrientation)
                                .ToListAsync();
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
            var personalData = await _context.PersonalDatas.FirstOrDefaultAsync(p => p.Id == id);

            if (personalData == null)
            {
                throw new DbDataNotFoundException($"No data found for the id : {id}");
            }

            return personalData;
        }

        public async Task UpdateAsync(PersonalData entity)
        {
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = "Process";
            
            _context.PersonalDatas.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

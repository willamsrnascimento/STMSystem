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
            _context.PersonalDatas.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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
                return null;
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

        public async Task<PersonalData> GetByIdAsync(int id)
        {
            var personalData = await _context.PersonalDatas.FirstOrDefaultAsync(p => p.id == id);

            if (personalData == null)
            {
                throw new DbDataNotFoundException($"No data found for the cpf: {id}");
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

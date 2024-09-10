using STMComunication.Dtos;
using STMDomain.Domain;

namespace STMComunication.Services.Interfaces
{
    public interface IPersonalDataService : IService<PersonalData>
    {
        Task CreateAsync2(PersonalDataRequestDto entity);
       
            
    }
}

using STMDomain.Domain;

namespace STMComunication.Services.Interfaces
{
    public interface IPersonalDataService : IServiceWriteOnly<PersonalData>, IServiceReadOnly<PersonalData>
    {        
    }
}

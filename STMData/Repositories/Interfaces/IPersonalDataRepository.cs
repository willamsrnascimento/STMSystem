using STMDomain.Domain;

namespace STMData.Repositories.Interfaces
{
    public interface IPersonalDataRepository : IRepository<PersonalData>
    {
        Task<PersonalData> GetByCPF(string cpf);
    }
}

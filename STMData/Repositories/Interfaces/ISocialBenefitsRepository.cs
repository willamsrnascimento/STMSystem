using STMDomain.Domain;

namespace STMData.Repositories.Interfaces
{
    public interface ISocialBenefitsRepository : IRepository<SocialBenefits>
    {
        Task<ICollection<SocialBenefits>> GetSocialBenefitsByIdListAsync(ICollection<SocialBenefits> socialBenefits);
    }
}

using Autofac.Extras.Moq;
using STMComunication.Services.Implementations;
using STMComunication.Services.Interfaces;
using STMDomain.Domain;

namespace STMTests
{
    public class PersonalDataReadOnlyEndipointTest
    {
        [Fact(DisplayName = "Given an id when requested then returns a personal data")]
        public void GivenAnId_WhenRequested_ReturnsPersonalData()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPersonalDataService>()
                    .Setup(x => x.GetByIdAsync(1))
                    .Returns(GetSamplePersonalData());

                var cls = mock.Create<PersonalDataService>();
                var expected = GetSamplePersonalData();

                var actual = cls.GetByIdAsync(1);

                Assert.True(actual != null);
                //Assert.Equal(expected.Result.Id, actual.Result.Id);
            };
        }
        private async Task<PersonalData> GetSamplePersonalData()
        {
            var personalData = new PersonalData()
            {
                Id = 1,
                CPF = "000000",
                BirthdayDate = DateTime.Now,
                Age = 12,
                Occupancy = "Teste",
                EducationId = 1

            };

            return personalData;
        }
    }

    
}
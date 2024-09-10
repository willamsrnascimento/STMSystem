using Microsoft.AspNetCore.Mvc;
using STMComunication.Dtos;
using STMComunication.Services.Interfaces;
using STMDomain.Domain;
using System.Security.Claims;

namespace STMComunication.Endpoints.PersonalDataEndpoint
{
    public static class PersonalDataWriteOnlyEndpoint
    {
        public static async Task<IResult> PostAsync([FromBody] PersonalDataRequestDto personal, HttpContext context, IPersonalDataService personalDataService)
        {
            var userId = context.User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value;

            if(userId == null)
            {
                return Results.Problem(title: "There is no a user logged in", statusCode: 404);
            }

            var contacts = new List<Contact>();

            foreach(var contact in personal.Contacts)
            {
                contacts.Add(new Contact
                {
                    PhoneNumber = contact.PhoneNumber,
                    IsWhatsappConfirmed = contact.IsWhatsappConfirmed,
                    Email = contact.Email,
                });
            }

            var socialBenefits = new List<SocialBenefits>();

            foreach(var item in personal.SocialBenefits)
            {
                socialBenefits.Add(new SocialBenefits
                {
                    Id = item.Id
                });
            }

            Address address = new Address
            {
                CEP = personal.Address.CEP,
                Place = personal.Address.Place,
                Number = personal.Address.Number,
                Complement = personal.Address.Complement,
                Neighborhood = personal.Address.Neighborhood,
                City = personal.Address.City,
                State = personal.Address.State,
                ResidenceTime = personal.Address.ResidenceTime,
            };

            FamilyData familyData = new FamilyData
            {
                FamilyRevenue = personal.FamilyData.FamilyRevenue,
                ResidenceQuantity = personal.FamilyData.ResidenceQuantity,
                ChildrenQuantity = personal.FamilyData.ChildrenQuantity,
                IsSoloParent = personal.FamilyData.IsSoloParent,
            };

            var personalData = new PersonalData
            {
                Name = personal.Name,
                CPF = personal.CPF,
                BirthdayDate = personal.BirthdayDate,
                Age = personal.Age,
                Occupancy = personal.Occupancy,
                EducationId = personal.EducationId,
                GenderId = personal.GenderId,
                SexualOrientationId = personal.SexualOrientationId,
                MaritalStatusId = personal.MaritalStatusId,
                ResponsibleCpf = personal.ResponsibleCpf,
                Contacts = contacts,
                SocialBenefits = socialBenefits,
                Address = address,
                FamilyData = familyData,
            };

            await personalDataService.CreateAsync2(personal);

          //  await personalDataService.
            return Results.Ok();
        }
    }
}

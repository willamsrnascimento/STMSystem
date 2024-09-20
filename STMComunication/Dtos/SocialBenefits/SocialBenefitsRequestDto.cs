namespace STMComunication.Dtos.SocialBenefits
{
    public record SocialBenefitsRequestDto
    {
        public string Description { get; set; }
        public string Detail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
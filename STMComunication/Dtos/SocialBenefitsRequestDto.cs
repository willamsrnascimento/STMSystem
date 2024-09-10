namespace STMComunication.Dtos
{
    public record SocialBenefitsRequestDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
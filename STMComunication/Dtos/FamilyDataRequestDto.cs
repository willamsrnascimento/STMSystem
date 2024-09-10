namespace STMComunication.Dtos
{
    public record FamilyDataRequestDto
    {
        public decimal FamilyRevenue { get; set; }
        public int ResidenceQuantity { get; set; }
        public int ChildrenQuantity { get; set; }
        public bool IsSoloParent { get; set; } = false;
    }
}